namespace FantasyBets.Tests.Evaluation
{
    public class TotalPointsFirstHalfHomeEvaluatorTests
    {
        [Fact]
        public void TotalPointsFirstHalfHomeEvaluator_ShouldReturnSuccess_WhenMoreThanBetAndMorePointsScoredInFirstHalfHome()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalfHome
                },
                Game = Fakes.Game(),
                Name = "Powyżej 40.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 21,
                }
            };
            var evaluator = new TotalPointsFirstHalfHomeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void TotalPointsFirstHalfHomeEvaluator_ShouldReturnFail_WhenMoreThanBetAndLessPointsScoredInFirstHalfHome()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalfHome
                },
                Game = Fakes.Game(),
                Name = "Powyżej 40.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                }
            };
            var evaluator = new TotalPointsFirstHalfHomeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void TotalPointsFirstHalfHomeEvaluator_ShouldReturnSuccess_WhenLessThanBetAndLessPointsScoredInFirstHalfHome()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalfHome
                },
                Game = Fakes.Game(),
                Name = "Poniżej 40.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                }
            };
            var evaluator = new TotalPointsFirstHalfHomeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }


        [Fact]
        public void TotalPointsFirstHalfHomeEvaluator_ShouldReturnFail_WhenLessThanBetAndMorePointsScoredInFirstHalfHome()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalfHome
                },
                Game = Fakes.Game(),
                Name = "Poniżej 40.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 21,
                }
            };
            var evaluator = new TotalPointsFirstHalfHomeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}