using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class OneOfPlayersScores20OrMore : OneOfPlayersScoresBase
    {
        public OneOfPlayersScores20OrMore(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.OneOfPlayersScores20OrMore;

        protected override int PointsThreshold => 20;
    }
}
