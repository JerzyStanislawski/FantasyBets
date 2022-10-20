using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class GameWinnerEvaluator : IEvaluatable
    {
        public BetCode BetCode => BetCode.Winner;

        public BetResult Evaluate(BetSelection betSelection, GameStats gameStats)
        {
            return BetResult.Pending;
        }
    }
}
