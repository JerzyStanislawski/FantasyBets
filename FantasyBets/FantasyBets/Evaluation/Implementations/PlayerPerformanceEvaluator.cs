using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerPerformanceEvaluator : PlayerBaseEvaluator
    {
        public PlayerPerformanceEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerPerformance;

        protected override int CalculateStatsValue(PlayerStats stats)
            => stats.Points + stats.Assists + stats.TotalRebounds;
    }
}
