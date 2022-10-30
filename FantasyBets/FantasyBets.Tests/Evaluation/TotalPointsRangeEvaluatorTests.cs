namespace FantasyBets.Tests.Evaluation
{
    public class TotalPointsRangeEvaluatorTests
    {
        [Theory]
        [InlineData("0-100", 50, 49, BetResult.Success)]
        [InlineData("0-100", 50, 51, BetResult.Fail)]
        [InlineData("0-100", 51, 49, BetResult.Success)]
        [InlineData("121-130", 60, 61, BetResult.Success)]
        [InlineData("121-130", 61, 59, BetResult.Fail)]
        [InlineData("180.5+", 90, 91, BetResult.Success)]
        [InlineData("180.5+", 91, 89, BetResult.Fail)]
        public void TotalPointsRangeEvaluator_ShouldReturnProperResult(string range, int homeScore, int awayScore, BetResult betResult)
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsRange
                },
                Game = Fakes.Game(),
                Name = range,
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = homeScore,
                ScoreAwayTeam = awayScore
            };
            var evaluator = new TotalPointsRangeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(betResult);
        }
    }
}
