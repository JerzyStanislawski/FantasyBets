using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Data
{
    public interface IDataProvider
    {
        Task<Team?> GetTeamBySymbol(string symbol);
        Task<Season?> GetSeasonByCode(string code);
    }

    public class DataProvider : IDataProvider
    {
        private readonly IDbContextFactory<DataContext> _dbContextFactory;

        public DataProvider(IDbContextFactory<DataContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Team?> GetTeamBySymbol(string symbol)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.Teams!.SingleOrDefaultAsync(t => t.Symbol == symbol);
        }

        public async Task<Season?> GetSeasonByCode(string code)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.Seasons!.SingleOrDefaultAsync(s => s.Code == code);
        }
    }
}
