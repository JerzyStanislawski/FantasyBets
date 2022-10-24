using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerTotalAssistsEvaluator : PlayerBaseEvaluator
    {
        public PlayerTotalAssistsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerTotalAssists;

        protected override int CalculateStatsValue(PlayerStats stats) => stats.Assists;
    }
}
