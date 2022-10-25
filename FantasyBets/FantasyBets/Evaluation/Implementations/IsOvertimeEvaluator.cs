using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class IsOvertimeEvaluator : BaseEvaluator
    {
        public IsOvertimeEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.Overtime;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var scoreEqual = gameStats.ScoreHomeTeamByQuarter.Quarter1 +
                   gameStats.ScoreHomeTeamByQuarter.Quarter2 +
                   gameStats.ScoreHomeTeamByQuarter.Quarter3 +
                   gameStats.ScoreHomeTeamByQuarter.Quarter4 ==
                   gameStats.ScoreAwayTeamByQuarter.Quarter1 +
                   gameStats.ScoreAwayTeamByQuarter.Quarter2 +
                   gameStats.ScoreAwayTeamByQuarter.Quarter3 +
                   gameStats.ScoreAwayTeamByQuarter.Quarter4;
            return (String.Equals(betSelection.Name, EvaluationConsts.Yes, StringComparison.InvariantCultureIgnoreCase) && scoreEqual)
                || (String.Equals(betSelection.Name, EvaluationConsts.No, StringComparison.InvariantCultureIgnoreCase) && !scoreEqual)
                   ? BetResult.Success
                   : BetResult.Fail;
        }
    }
}
