using FantasyBets.Data;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public abstract class TotalStatsItemBaseEvaluator : BaseEvaluator
    {
        public TotalStatsItemBaseEvaluator(Configuration configuration) : base(configuration)
        {
        }

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var difference = EvaluationHelpers.ParseDifference(betSelection.Name);

            var statsValue = GetStatsItem(gameStats);

            return difference.Type == DifferenceType.MoreThan
                ? (statsValue > difference.Value ? BetResult.Success : BetResult.Fail)
                : (statsValue < difference.Value ? BetResult.Success : BetResult.Fail);
        }

        protected abstract int GetStatsItem(GameStats gameStats);
    }
}
