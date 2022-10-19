using FantasyBets.Data;
using FantasyBets.Logic.Parsers;
using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Services
{
    public class GameStatsHostedService : BackgroundService
    {
        private readonly IDbContextFactory<DataContext> _dbContextFactory;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GameStatsParser _gameStatsParser;
        private readonly Configuration _configuration;
        private readonly ILogger _logger;
        private readonly PeriodicTimer _timer;
        private PeriodicTimer? _roundTimer;

        public GameStatsHostedService(
            IDbContextFactory<DataContext> dbContextFactory,
            IHttpClientFactory httpClientFactory,
            GameStatsParser gameStatsParser,
            Configuration configuration,
            ILogger<UpdateBetsHostedService> logger)
        {
            _dbContextFactory = dbContextFactory;
            _httpClientFactory = httpClientFactory;
            _gameStatsParser = gameStatsParser;
            _configuration = configuration;
            _logger = logger;
            _timer = new PeriodicTimer(TimeSpan.FromHours(1));
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            do
            {
                try
                {
                    _logger.LogInformation("Checking game stats");
                    using var dbContext = await _dbContextFactory.CreateDbContextAsync();
                    var currentRound = dbContext.Rounds!
                        .Include(x => x.Games)
                        .ThenInclude(x => x.BetSelections)
                        .FirstOrDefault(x => x.StartTime < DateTime.UtcNow && x.EndTime.AddHours(40000) > DateTime.UtcNow);

                    if (currentRound is not null)
                    {
                        if (_roundTimer is null)
                            _roundTimer = new PeriodicTimer(TimeSpan.FromMinutes(1));
                        await TrackGames(currentRound);
                    }
                    else
                    {
                        _roundTimer?.Dispose();
                        _roundTimer = null;
                        _logger.LogInformation("No active rounds");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing game stats.");
                }
            }
            while (((_roundTimer != null && await _roundTimer!.WaitForNextTickAsync(cancellationToken))
                || await _timer.WaitForNextTickAsync(cancellationToken))
                && !cancellationToken.IsCancellationRequested);
        }

        private async Task TrackGames(Round currentRound)
        {
            var games = currentRound.Games.Where(x => x.Time < DateTime.UtcNow && x.Time.AddHours(40000) > DateTime.UtcNow
                && x.BetSelections.Any(x => x.Result == BetResult.Pending));

            var tasks = new List<Task>();
            foreach (var game in games)
            {
                tasks.Add(Task.Run(async () =>
                {
                    await TrackGame(game);
                }));
            }

            await Task.WhenAll(tasks);
        }

        private async Task TrackGame(Game game)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var url = String.Format(_configuration.Feeds.GameStats, game.Code, _configuration.CurrentSeasonCode);
            try
            {
                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Error downloading game stats, url: {url}, status code: {response.StatusCode}");
                }
                var payload = await response.Content.ReadAsStringAsync();
                var gameStats = _gameStatsParser.Parse(payload);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error downloading game stats, url: {url}");
            }
        }
    }
}
