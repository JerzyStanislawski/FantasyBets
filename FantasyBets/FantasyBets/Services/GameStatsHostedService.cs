using FantasyBets.Data;
using FantasyBets.Evaluation;
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
        private readonly BetsEvaluator _betsEvaluator;
        private readonly ILogger _logger;
        private readonly PeriodicTimer _timer;

        public GameStatsHostedService(
            IDbContextFactory<DataContext> dbContextFactory,
            IHttpClientFactory httpClientFactory,
            GameStatsParser gameStatsParser,
            Configuration configuration,
            BetsEvaluator betsEvaluator,
            ILogger<GameStatsHostedService> logger)
        {
            _dbContextFactory = dbContextFactory;
            _httpClientFactory = httpClientFactory;
            _gameStatsParser = gameStatsParser;
            _configuration = configuration;
            _betsEvaluator = betsEvaluator;
            _logger = logger;
            _timer = new PeriodicTimer(TimeSpan.FromMinutes(5));
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            do
            {
                try
                {
                    _logger.LogInformation("Checking game stats");
                    using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
                    var games = dbContext.Rounds!
                        .Include(x => x.Games)
                        .ThenInclude(x => x.BetSelections)
                        .ThenInclude(x => x.BetType)
                        .Include(x => x.Games)
                        .ThenInclude(x => x.AwayTeam)
                        .Include(x => x.Games)
                        .ThenInclude(x => x.HomeTeam)
                        .SelectMany(x => x.Games)
                        .Where(x => x.BetSelections.Any(b => b.Result == BetResult.Pending));

                    if (games.Any())
                    {
                        await TrackGames(games);
                    }
                    else
                    {
                        _logger.LogInformation("No games to track");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing game stats.");
                }
            }
            while (await _timer.WaitForNextTickAsync(cancellationToken) && !cancellationToken.IsCancellationRequested);
        }

        private async Task TrackGames(IEnumerable<Game> games)
        {
            _logger.LogInformation("Games to track: {count}", games.Count());

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
            _logger.LogInformation("Tracking game {code} {homeTeam}-{awayTeam}", game.Code, game.HomeTeam.Name, game.AwayTeam.Name);
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
                _logger.LogInformation("Game parsed {code}, {isLive}", game.Code, gameStats?.IsLive);

                if (gameStats != null && !gameStats.IsLive && gameStats.ScoreHomeTeam > 0 && gameStats.ScoreAwayTeam > 0)
                {
                    await _betsEvaluator.Evaluate(game.BetSelections.Where(x => x.Result == BetResult.Pending), gameStats!);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing game stats, url: {url}", url);
            }
        }
    }
}
