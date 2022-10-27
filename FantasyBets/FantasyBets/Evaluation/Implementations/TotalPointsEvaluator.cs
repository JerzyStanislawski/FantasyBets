using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsEvaluator : TotalStatsItemBaseEvaluator
    {
        public TotalPointsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPoints;

        protected override int GetStatsItem(GameStats gameStats)
            => gameStats.ScoreAwayTeam + gameStats.ScoreHomeTeam;
    }
}
