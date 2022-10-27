using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsAwayTeamEvaluator : TotalStatsItemBaseEvaluator
    {
        public TotalPointsAwayTeamEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPointsAway;

        protected override int GetStatsItem(GameStats gameStats)
            => gameStats.ScoreAwayTeam;
    }
}
