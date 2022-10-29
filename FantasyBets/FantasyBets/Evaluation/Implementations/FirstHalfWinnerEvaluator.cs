using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class FirstHalfWinnerEvaluator : BaseEvaluator
    {
        public FirstHalfWinnerEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.FirstHalfWinner;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var homeTeamHalftimeScore = EvaluationHelpers.PointsInHalftime(gameStats.ScoreHomeTeamByQuarter);
            var awayTeamHalftimeScore = EvaluationHelpers.PointsInHalftime(gameStats.ScoreAwayTeamByQuarter);

            if (HomeTeamBet(betSelection.Game, betSelection.Name))
            {
                return homeTeamHalftimeScore > awayTeamHalftimeScore
                    ? BetResult.Success
                    : BetResult.Fail;
            }
            else if (AwayTeamBet(betSelection.Game, betSelection.Name))
            {
                return homeTeamHalftimeScore < awayTeamHalftimeScore
                    ? BetResult.Success
                    : BetResult.Fail;
            }
            else
                return BetResult.Cancelled;
        }
    }
}
