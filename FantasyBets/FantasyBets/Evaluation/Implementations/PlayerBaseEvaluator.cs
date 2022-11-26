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
            var pos = betSelection.Name.LastIndexOf('-');
            var name = betSelection.Name[..pos].Trim();
            var expression = betSelection.Name[(pos + 1)..].Trim();

            var statsLine = EvaluationHelpers.GetPlayerStats(gameStats, name);

            if (statsLine is null)
                return BetResult.Cancelled;

            var statsValue = CalculateStatsValue(statsLine);

            var difference = EvaluationHelpers.ParseDifference(expression);

            return difference.Type == DifferenceType.MoreThan
                ? (statsValue > difference.Value ? BetResult.Success : BetResult.Fail)
                : (statsValue < difference.Value ? BetResult.Success : BetResult.Fail);
        }

        protected abstract int CalculateStatsValue(PlayerStats stats);

    }
}
