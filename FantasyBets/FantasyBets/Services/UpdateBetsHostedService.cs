namespace FantasyBets.Services
{
    public class UpdateBetsHostedService : IHostedService
    {
        private readonly Configuration _configuration;
        private readonly ILogger _logger;
        private readonly PeriodicTimer _timer;

        public UpdateBetsHostedService(Configuration configuration, ILogger logger)
        {
            _configuration = configuration;
            _timer = new PeriodicTimer(_configuration.RefreshBetsFrequency);
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            do
            {

            }
            while (await _timer.WaitForNextTickAsync(cancellationToken) && !cancellationToken.IsCancellationRequested);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
