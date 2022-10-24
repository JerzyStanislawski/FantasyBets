using FantasyBets.Data;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public abstract class OneOfPlayersScoresBase : BaseEvaluator
    {
        protected OneOfPlayersScoresBase(Configuration configuration) : base(configuration)
        {
        }

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var players = betSelection.Name.Split('/');

            var statsLine1 = EvaluationHelpers.GetPlayerStats(gameStats, players[0].Trim());
            var statsLine2 = EvaluationHelpers.GetPlayerStats(gameStats, players[1].Trim());

            if (statsLine1 is null && statsLine2 is null)
                return BetResult.Cancelled;

            return statsLine1?.Points >= PointsThreshold || statsLine2?.Points >= PointsThreshold
                ? BetResult.Success
                : BetResult.Fail;
        }

        protected abstract int PointsThreshold { get; }
    }
}
