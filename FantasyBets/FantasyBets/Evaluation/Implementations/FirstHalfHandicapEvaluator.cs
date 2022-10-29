using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class FirstHalfHandicapEvaluator : BaseEvaluator
    {
        public FirstHalfHandicapEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.FirstHalfWinnerHandicap;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var homeTeamHalftimeScore = EvaluationHelpers.PointsInHalftime(gameStats.ScoreHomeTeamByQuarter);
            var awayTeamHalftimeScore = EvaluationHelpers.PointsInHalftime(gameStats.ScoreAwayTeamByQuarter);

            var parsedBet = EvaluationHelpers.ParseTeamAndHandicap(betSelection.Name);

            if (HomeTeamBet(betSelection.Game, parsedBet.Team))
            {
                return homeTeamHalftimeScore + parsedBet.Handicap > awayTeamHalftimeScore
                    ? BetResult.Success
                    : homeTeamHalftimeScore + parsedBet.Handicap < awayTeamHalftimeScore
                        ? BetResult.Fail
                        : BetResult.Pending;
            }
            else if (AwayTeamBet(betSelection.Game, parsedBet.Team))
            {
                return homeTeamHalftimeScore < awayTeamHalftimeScore + parsedBet.Handicap
                    ? BetResult.Success
                    : homeTeamHalftimeScore > awayTeamHalftimeScore + parsedBet.Handicap
                        ? BetResult.Fail
                        : BetResult.Pending;
            }
            else
                return BetResult.Cancelled;
        }
    }
}
