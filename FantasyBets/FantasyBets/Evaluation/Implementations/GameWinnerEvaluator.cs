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
                return gameStats.ScoreHomeTeam > gameStats.ScoreAwayTeam
                    ? BetResult.Success
                    : gameStats.ScoreHomeTeam < gameStats.ScoreAwayTeam
                        ? BetResult.Fail
                        : BetResult.Pending;
            }
            else if (AwayTeamBet(betSelection.Game, betSelection.Name))
            {
                return gameStats.ScoreHomeTeam < gameStats.ScoreAwayTeam
                    ? BetResult.Success
                    : gameStats.ScoreHomeTeam > gameStats.ScoreAwayTeam
                        ? BetResult.Fail
                        : BetResult.Pending;
            }
            else
                return BetResult.Cancelled;
        }
    }
}
