using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerScores20Evaluator : PlayerScoresMoreThanBaseEvaluator
    {
        public PlayerScores20Evaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerScores20OrMore;

        public override int PointsThreshold => 20;
    }
}
