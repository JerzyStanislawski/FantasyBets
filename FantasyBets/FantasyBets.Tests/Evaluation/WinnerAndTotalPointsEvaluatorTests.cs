namespace FantasyBets.Tests.Evaluation
{
    public class WinnerAndTotalPointsEvaluatorTests
    {
        [Theory]
        [InlineData("Barcelona I powyżej 160.5", 81, 80, BetResult.Success)]
        [InlineData("Barcelona I poniżej 160.5", 81, 80, BetResult.Fail)]
        [InlineData("Barcelona I poniżej 160.5", 81, 79, BetResult.Success)]
        [InlineData("Barcelona I powyżej 160.5", 81, 79, BetResult.Fail)]
        [InlineData("Barcelona I powyżej 160.5", 80, 81, BetResult.Fail)]
        [InlineData("Barcelona I poniżej 160.5", 79, 80, BetResult.Fail)]
        [InlineData("Real Madrid I powyżej 160.5", 80, 81, BetResult.Success)]
        [InlineData("Real Madrid I poniżej 160.5", 80, 81, BetResult.Fail)]
        [InlineData("Real Madrid I poniżej 160.5", 77, 79, BetResult.Success)]
        [InlineData("Real Madrid I powyżej 160.5", 75, 85, BetResult.Fail)]
        [InlineData("Real Madrid I powyżej 160.5", 81, 80, BetResult.Fail)]
        [InlineData("Real Madrid I poniżej 160.5", 79, 77, BetResult.Fail)]
        public void WinnerAndTotalPointsEvaluator_ShouldReturnProperResult(string betName, int homeScore, int awayScore, BetResult betResult)
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerAndTotalPoints
                },
                Game = Fakes.Game(),
                Name = betName,
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = homeScore,
                ScoreAwayTeam = awayScore
            };
            var evaluator = new WinnerAndTotalPointsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(betResult);
        }
    }
}
