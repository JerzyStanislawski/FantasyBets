using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerTotalReboundsEvaluator : PlayerBaseEvaluator
    {
        public PlayerTotalReboundsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerTotalRebounds;

        protected override int CalculateStatsValue(PlayerStats stats) => stats.TotalRebounds;
    }
}
