using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class GameWinnerEvaluator : BaseEvaluator
    {
        public GameWinnerEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.Winner;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            if (HomeTeamBet(betSelection.Game, betSelection.Name))
            {
                return gameStats.HomeTeamStats.Points > gameStats.AwayTeamStats.Points
                    ? BetResult.Success
                    : BetResult.Fail;
            }
            else if (AwayTeamBet(betSelection.Game, betSelection.Name))
            {
                return gameStats.HomeTeamStats.Points < gameStats.AwayTeamStats.Points
                    ? BetResult.Success
                    : BetResult.Fail;
            }
            else
                return BetResult.Cancelled;
        }
    }
}
