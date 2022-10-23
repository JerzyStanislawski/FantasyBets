using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsHomeTeamEvaluator : TotalPointsBaseEvaluator
    {
        public TotalPointsHomeTeamEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPointsHome;

        protected override int CalculateTotalPoints(GameStats gameStats)
            => gameStats.ScoreHomeTeam;
    }
}
