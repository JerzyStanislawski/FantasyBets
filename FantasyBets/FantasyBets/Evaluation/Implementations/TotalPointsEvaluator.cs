using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsEvaluator : TotalPointsBaseEvaluator
    {
        public TotalPointsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPoints;

        protected override int CalculateTotalPoints(GameStats gameStats)
            => gameStats.ScoreAwayTeam + gameStats.ScoreHomeTeam;
    }
}
