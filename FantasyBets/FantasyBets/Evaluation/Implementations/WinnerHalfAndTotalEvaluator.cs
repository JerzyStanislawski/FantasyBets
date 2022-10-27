using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class WinnerHalfAndTotalEvaluator : BaseEvaluator

    {
        public WinnerHalfAndTotalEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.WinnerHalfAndTotal;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var results = betSelection.Name.Split('/');

            var firstHalfBetResult = results[0].Trim();
            var gameBetResult = results[1].Trim();

            var homeTeamName = _configuration.BettingFeedTeamNames[betSelection.Game.HomeTeam.Symbol];
            var awayTeamName = _configuration.BettingFeedTeamNames[betSelection.Game.AwayTeam.Symbol];

            var homeTeamHalfScore = gameStats.ScoreHomeTeamByQuarter.Quarter1 + gameStats.ScoreHomeTeamByQuarter.Quarter2;
            var awayTeamHalfScore = gameStats.ScoreAwayTeamByQuarter.Quarter1 + gameStats.ScoreAwayTeamByQuarter.Quarter2;
            var homeTeamTotalScore = gameStats.ScoreHomeTeamByQuarter.Quarter1 + gameStats.ScoreHomeTeamByQuarter.Quarter2 + gameStats.ScoreHomeTeamByQuarter.Quarter3 + gameStats.ScoreHomeTeamByQuarter.Quarter4;
            var awayTeamTotalScore = gameStats.ScoreAwayTeamByQuarter.Quarter1 + gameStats.ScoreAwayTeamByQuarter.Quarter2 + gameStats.ScoreAwayTeamByQuarter.Quarter3 + gameStats.ScoreAwayTeamByQuarter.Quarter4;

            var halfResult = GetResult(homeTeamHalfScore, awayTeamHalfScore);
            var gameResult = GetResult(homeTeamTotalScore, awayTeamTotalScore);

            var expectedHalfResult = GetWinningTeamName(halfResult, homeTeamName, awayTeamName);
            var expectedGameResult = GetWinningTeamName(gameResult, homeTeamName, awayTeamName);

            return String.Equals(expectedHalfResult, firstHalfBetResult, StringComparison.CurrentCultureIgnoreCase)
                && String.Equals(expectedGameResult, gameBetResult, StringComparison.CurrentCultureIgnoreCase)
                ? BetResult.Success
                : BetResult.Fail;
        }

        private string GetWinningTeamName(GameResult result, string homeTeamName, string awayTeamName)
            => result == GameResult.Home
                ? homeTeamName
                : result == GameResult.Away
                    ? awayTeamName
                    : EvaluationConsts.Draw;

        private static GameResult GetResult(int homeTeamScore, int awayTeamScore)
            => homeTeamScore > awayTeamScore
                ? GameResult.Home
                : homeTeamScore < awayTeamScore
                    ? GameResult.Away
                    : GameResult.Draw;

        enum GameResult
        {
            Home,
            Draw,
            Away
        }
    }
}
