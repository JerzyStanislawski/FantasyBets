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
            var scoreEqual = EvaluationHelpers.ScoreEqualInRegulationTime(gameStats);

            return (String.Equals(betSelection.Name, EvaluationConsts.Yes, StringComparison.InvariantCultureIgnoreCase) && scoreEqual)
                || (String.Equals(betSelection.Name, EvaluationConsts.No, StringComparison.InvariantCultureIgnoreCase) && !scoreEqual)
                   ? BetResult.Success
                   : BetResult.Fail;
        }
    }
}
