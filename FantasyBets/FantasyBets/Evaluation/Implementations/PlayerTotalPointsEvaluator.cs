using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerTotalPointsEvaluator : PlayerBaseEvaluator
    {
        public PlayerTotalPointsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerTotalPoints;

        protected override int CalculateStatsValue(PlayerStats stats) => stats.Points;
    }
}
