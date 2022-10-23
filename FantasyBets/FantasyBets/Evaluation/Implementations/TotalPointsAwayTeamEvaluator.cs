using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsAwayTeamEvaluator : TotalPointsBaseEvaluator
    {
        public TotalPointsAwayTeamEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPointsAway;

        protected override int CalculateTotalPoints(GameStats gameStats)
            => gameStats.ScoreAwayTeam;
    }
}
