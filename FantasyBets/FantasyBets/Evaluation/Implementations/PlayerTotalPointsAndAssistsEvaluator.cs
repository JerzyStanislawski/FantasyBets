using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerTotalPointsAndAssistsEvaluator : PlayerBaseEvaluator
    {
        public PlayerTotalPointsAndAssistsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerTotalPointsAndAssists;

        protected override int CalculateStatsValue(PlayerStats stats) => stats.Points + stats.Assists;
    }
}
