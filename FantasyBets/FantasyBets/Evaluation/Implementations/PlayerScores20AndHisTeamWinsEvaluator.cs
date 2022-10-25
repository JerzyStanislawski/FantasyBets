using FantasyBets.Model.Bets;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerScores20AndHisTeamWinsEvaluator : PlayerScoresMoreThanAndHisTeamWinsBaseEvaluator
    {
        public PlayerScores20AndHisTeamWinsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerScores20OrMoreAndHisTeamWins;

        public override int PointsThreshold => 20;
    }
}
