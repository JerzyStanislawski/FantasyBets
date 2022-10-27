using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsHomeTeamEvaluator : TotalStatsItemBaseEvaluator
    {
        public TotalPointsHomeTeamEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPointsHome;

        protected override int GetStatsItem(GameStats gameStats)
            => gameStats.ScoreHomeTeam;
    }
}
