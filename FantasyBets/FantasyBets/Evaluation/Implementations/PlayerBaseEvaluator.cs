using FantasyBets.Data;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public abstract class PlayerBaseEvaluator : BaseEvaluator
    {
        protected PlayerBaseEvaluator(Configuration configuration) : base(configuration)
        {
        }

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var parsed = betSelection.Name.Split('-');
            var statsLine = EvaluationHelpers.GetPlayerStats(gameStats, parsed[0]);

            if (statsLine is null)
                return BetResult.Cancelled;

            var statsValue = CalculateStatsValue(statsLine);

            var difference = EvaluationHelpers.ParseDifference(parsed[1]);

            return difference.Type == DifferenceType.MoreThan
                ? (statsValue > difference.Value ? BetResult.Success : BetResult.Fail)
                : (statsValue < difference.Value ? BetResult.Success : BetResult.Fail);
        }

        protected abstract int CalculateStatsValue(PlayerStats stats);

    }
}
