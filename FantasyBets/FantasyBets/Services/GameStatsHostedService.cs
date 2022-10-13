using FantasyBets.Data;
using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Services
{
    public class GameStatsHostedService : BackgroundService
    {
        private readonly IDbContextFactory<DataContext> _dbContextFactory;
        private readonly ILogger _logger;
        private readonly PeriodicTimer _timer;

        public GameStatsHostedService(
            IDbContextFactory<DataContext> dbContextFactory,
            ILogger<UpdateBetsHostedService> logger)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
            _timer = new PeriodicTimer(TimeSpan.FromHours(1));
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            do
            {
                try
                {
                    using var dbContext = await _dbContextFactory.CreateDbContextAsync();
                    dbContext.Rounds.Where(x => x.StartTime)
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing game stats.");
                }
            }
            while (await _timer.WaitForNextTickAsync(cancellationToken) && !cancellationToken.IsCancellationRequested);
        }


    }
}
