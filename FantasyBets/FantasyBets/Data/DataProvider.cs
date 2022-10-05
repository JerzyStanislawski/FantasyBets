using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Data
{
    public interface IDataProvider
    {
        Task<Team?> GetTeamBySymbol(string symbol);
        Task<Season?> GetSeasonByCode(string code);
        Task<IEnumerable<Game>> GetGamesByRound(int round);
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

        public async Task<IEnumerable<Game>> GetGamesByRound(int roundNumber)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var round = await dbContext.Rounds!
                .Include(x => x.Games).ThenInclude(x => x.HomeTeam)
                .Include(x => x.Games).ThenInclude(x => x.AwayTeam)
                .FirstOrDefaultAsync(x => x.Number == roundNumber);

            if (round is null)
                throw new ArgumentException("Incorrect round number");

            return round!.Games;
        }
    }
}
