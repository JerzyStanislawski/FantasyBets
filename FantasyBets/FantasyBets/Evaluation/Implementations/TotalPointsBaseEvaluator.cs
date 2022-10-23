using FantasyBets.Data;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public abstract class TotalPointsBaseEvaluator : BaseEvaluator
    {
        public TotalPointsBaseEvaluator(Configuration configuration) : base(configuration)
        {
        }

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var difference = EvaluationHelpers.ParseDifference(betSelection.Name);

            var statsValue = CalculateTotalPoints(gameStats);

            return difference.Type == DifferenceType.MoreThan
                ? (statsValue > difference.Value ? BetResult.Success : BetResult.Fail)
                : (statsValue < difference.Value ? BetResult.Success : BetResult.Fail);
        }

        protected abstract int CalculateTotalPoints(GameStats gameStats);
    }
}
