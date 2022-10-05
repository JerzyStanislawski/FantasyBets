using FantasyBets.Logic.Parsers;

namespace FantasyBets.Services
{
    public class UpdateBetsHostedService : BackgroundService
    {
        private readonly Configuration _configuration;
        private readonly RoundBetsParser _roundBetsParser;
        private readonly GameBetsParser _gameBetsParser;
        private readonly CurrentRoundProvider _currentRoundProvider;
        private readonly IBetsProvider _betsProvider;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;
        private readonly PeriodicTimer _timer;

        public UpdateBetsHostedService(Configuration configuration, 
            RoundBetsParser roundBetsParser, 
            GameBetsParser gameBetsParser, 
            CurrentRoundProvider currentRoundProvider,
            IBetsProvider betsProvider,
            IHttpClientFactory httpClientFactory,
            ILogger<UpdateBetsHostedService> logger)
        {
            _configuration = configuration;
            _roundBetsParser = roundBetsParser;
            _gameBetsParser = gameBetsParser;
            _currentRoundProvider = currentRoundProvider;
            _betsProvider = betsProvider;
            _httpClientFactory = httpClientFactory;
            _timer = new PeriodicTimer(_configuration.RefreshBetsFrequency);
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            do
            {
                try
                {
                    _logger.LogInformation("Updating bets");

                    var httpClient = _httpClientFactory.CreateClient(nameof(UpdateBetsHostedService));
                    var roundResponse = await httpClient.GetAsync(_configuration.Feeds.RoundBets, cancellationToken);
                    if (!roundResponse.IsSuccessStatusCode)
                    {
                        _logger.LogError($"Downloading round bets not successful. Http status code: {roundResponse.StatusCode}");
                        continue;
                    }

                    var roundPayload = await roundResponse.Content.ReadAsStringAsync(cancellationToken);
                    var roundBets = _roundBetsParser.Parse(roundPayload);

                    foreach (var match in roundBets.Matches)
                    {
                        try
                        {
                            _logger.LogInformation($"Updating bets for match id={match.Id}");
                            var gameBetsUrl = String.Format(_configuration.Feeds.GameBets, match.Id);

                            var gameBetsResponse = await httpClient.GetAsync(gameBetsUrl, cancellationToken);
                            if (!gameBetsResponse.IsSuccessStatusCode)
                            {
                                _logger.LogError($"Downloading game bets not successful. Http status code: {gameBetsResponse.StatusCode}");
                                continue;
                            }

                            var betsPayload = await gameBetsResponse.Content.ReadAsStringAsync(cancellationToken);
                            var bets = await _gameBetsParser.Parse(betsPayload, await _currentRoundProvider.GetCurrentRoundNumber());

                            _betsProvider.Bets.RemoveAll(x => x.Game.HomeTeamId == bets.Game.HomeTeamId &&
                                                              x.Game.AwayTeamId == bets.Game.AwayTeamId);
                            _betsProvider.Bets.Add(bets);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, $"Error updating bets for game id={match.Id}.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating bets.");
                }
            }
            while (await _timer.WaitForNextTickAsync(cancellationToken) && !cancellationToken.IsCancellationRequested);
        }
    }
}
