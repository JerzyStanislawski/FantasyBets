using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerScores25AndHisTeamWinsEvaluator : PlayerScoresMoreThanAndHisTeamWinsBaseEvaluator
    {
        public PlayerScores25AndHisTeamWinsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerScores25OrMoreAndHisTeamWins;

        public override int PointsThreshold => 25;
    }
}
