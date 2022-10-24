using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerTotalPointsAndReboundsEvaluator : PlayerBaseEvaluator
    {
        public PlayerTotalPointsAndReboundsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerTotalPointsAndRebounds;

        protected override int CalculateStatsValue(PlayerStats stats) => stats.Points + stats.TotalRebounds;
    }
}
