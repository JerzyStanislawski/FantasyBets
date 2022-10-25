using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerScores30AndHisTeamWinsEvaluator : PlayerScoresMoreThanAndHisTeamWinsBaseEvaluator
    {
        public PlayerScores30AndHisTeamWinsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerScores30OrMoreAndHisTeamWins;

        public override int PointsThreshold => 30;
    }
}
