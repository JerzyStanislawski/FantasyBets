using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class OneOfPlayersScores25OrMore : OneOfPlayersScoresBase
    {
        public OneOfPlayersScores25OrMore(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.OneOfPlayersScores25OrMore;

        protected override int PointsThreshold => 25;
    }
}
