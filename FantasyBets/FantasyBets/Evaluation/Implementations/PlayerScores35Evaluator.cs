using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerScores35Evaluator : PlayerScoresMoreThanBaseEvaluator
    {
        public PlayerScores35Evaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerScores35OrMore;

        public override int PointsThreshold => 35;
    }
}
