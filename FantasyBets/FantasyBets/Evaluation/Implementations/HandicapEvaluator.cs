using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class HandicapEvaluator : BaseEvaluator
    {
        public HandicapEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.Handicap;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var parsedBet = EvaluationHelpers.ParseTeamAndHandicap(betSelection.Name);

            if (HomeTeamBet(betSelection.Game, parsedBet.Team))
            {
                return gameStats.HomeTeamStats.Points + parsedBet.Handicap > gameStats.AwayTeamStats.Points
                    ? BetResult.Success
                    : gameStats.HomeTeamStats.Points + parsedBet.Handicap < gameStats.AwayTeamStats.Points
                        ? BetResult.Fail
                        : BetResult.Pending;
            }
            else if (AwayTeamBet(betSelection.Game, parsedBet.Team))
            {
                return gameStats.HomeTeamStats.Points < gameStats.AwayTeamStats.Points + parsedBet.Handicap
                    ? BetResult.Success
                    : gameStats.HomeTeamStats.Points > gameStats.AwayTeamStats.Points + parsedBet.Handicap
                        ? BetResult.Fail
                        : BetResult.Pending;
            }
            else
                return BetResult.Cancelled;
        }
    }
}
