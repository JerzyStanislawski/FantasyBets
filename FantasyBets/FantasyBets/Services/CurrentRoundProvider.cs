using FantasyBets.Data;
using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Services
{
    public class CurrentRoundProvider
    {
        private readonly IDbContextFactory<DataContext> _dbContextFactory;
        private readonly Configuration _configuration;

        public CurrentRoundProvider(IDbContextFactory<DataContext> dbContextFactory, Configuration configuration)
        {
            _dbContextFactory = dbContextFactory;
            _configuration = configuration;
        }

        public async Task<int> GetCurrentRoundNumber()
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var rounds = dbContext.Rounds!
                .Include(x => x.Season)
                .Where(x => x.Season.Code == _configuration.CurrentSeasonCode);
             var round = rounds.OrderBy(x => x.StartTime)
                .FirstOrDefault(x => x.EndTime.Date >= DateTime.Now.Date);

            return round is null ? rounds.Count() : round.Number;
        }
    }
}
