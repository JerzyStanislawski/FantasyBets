namespace FantasyBets.Tests.Evaluation
{
    public class TotalPointsEvaluatorTests
    {
        [Fact]
        public void TotalPointsEvaluator_ShouldReturnSuccess_WhenMoreThanBetAndMorePointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPoints
                },
                Game = Fakes.Game(),
                Name = "Powyżej 160.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 81,
                ScoreAwayTeam = 80
            };
            var evaluator = new TotalPointsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void TotalPointsEvaluator_ShouldReturnFail_WhenLessThanBetAndMorePointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPoints
                },
                Game = Fakes.Game(),
                Name = "Poniżej 160.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 81,
                ScoreAwayTeam = 80
            };
            var evaluator = new TotalPointsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void TotalPointsEvaluator_ShouldReturnSuccess_WhenLessThanBetAndLessPointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPoints
                },
                Game = Fakes.Game(),
                Name = "Poniżej 160.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 79,
                ScoreAwayTeam = 80
            };
            var evaluator = new TotalPointsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }


        [Fact]
        public void TotalPointsEvaluator_ShouldReturnFail_WhenMoreThanBetAndLessPointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPoints
                },
                Game = Fakes.Game(),
                Name = "Powyżej 160.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 79,
                ScoreAwayTeam = 80
            };
            var evaluator = new TotalPointsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
