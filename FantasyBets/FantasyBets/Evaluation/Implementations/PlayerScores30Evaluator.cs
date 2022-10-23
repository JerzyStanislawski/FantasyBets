using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerScores30Evaluator : PlayerScoresMoreThanBaseEvaluator
    {
        public PlayerScores30Evaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerScores30OrMore;

        public override int PointsThreshold => 30;
    }
}
