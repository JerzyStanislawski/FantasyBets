using FantasyBets.Data;
using FantasyBets.Model.Bets;
using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Services
{
    public class BettingService
    {
        private readonly IDbContextFactory<DataContext> _dbContextFactory;

        public BettingService(IDbContextFactory<DataContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task PlaceBet(GameBetSelection selection, GameBet gameBet, Game game, FantasyUser user)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var betType = await dbContext.BetTypes!.FirstOrDefaultAsync(x => x.BetCode == gameBet.BetCode);
            if (betType == null)
            {
                betType = new BetType
                {
                    BetCode = gameBet.BetCode,
                    Descripion = gameBet.Descripion
                };
            }

            var betSelection = new BetSelection
            {
                BetType = betType,
                Name = selection.Name,
                Odds = selection.Odds,
                UserId = user.Id,
                GameId = game.Id
            };

            var currentBet = await dbContext.BetSelections!.FirstOrDefaultAsync(x => x.GameId == game.Id && x.UserId == user.Id);
            if (currentBet is not null)
                dbContext.BetSelections!.Remove(currentBet);

            await dbContext.BetSelections!.AddAsync(betSelection);

            await dbContext.SaveChangesAsync();
        }
    }
}
