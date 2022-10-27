using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class OneOfPlayersScores25OrMoreEvaluator : OneOfPlayersScoresBaseEvaluator
    {
        public OneOfPlayersScores25OrMoreEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.OneOfPlayersScores25OrMore;

        protected override int PointsThreshold => 25;
    }
}
