using FantasyBets.Data;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public abstract class PlayerScoresMoreThanBaseEvaluator : BaseEvaluator
    {
        public PlayerScoresMoreThanBaseEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public abstract int PointsThreshold { get; }

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var statsLine = EvaluationHelpers.GetPlayerStats(gameStats, betSelection.Name);
            if (statsLine is null)
                return BetResult.Cancelled;

            return statsLine.Points >= PointsThreshold 
                ? BetResult.Success 
                : BetResult.Fail;
        }
    }
}
