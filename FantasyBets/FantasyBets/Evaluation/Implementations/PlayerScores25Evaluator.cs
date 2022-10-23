using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerScores25Evaluator : PlayerScoresMoreThanBaseEvaluator
    {
        public PlayerScores25Evaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerScores25OrMore;

        public override int PointsThreshold => 25;
    }
}
