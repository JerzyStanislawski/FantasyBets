using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class OneOfPlayersScores20OrMoreEvaluator : OneOfPlayersScoresBaseEvaluator
    {
        public OneOfPlayersScores20OrMoreEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.OneOfPlayersScores20OrMore;

        protected override int PointsThreshold => 20;
    }
}
