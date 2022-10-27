using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerTotalReboundsAndAssistsEvaluator : PlayerBaseEvaluator
    {
        public PlayerTotalReboundsAndAssistsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerTotalReboundsAndAssists;

        protected override int CalculateStatsValue(PlayerStats stats) => stats.TotalRebounds + stats.Assists;
    }
}
