namespace FantasyBets.Tests.Evaluation
{
    public class TotalPointsFirstHalfEvaluatorTests
    {
        [Fact]
        public void TotalPointsFirstHalfEvaluator_ShouldReturnSuccess_WhenMoreThanBetAndMorePointsScoredInFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalf
                },
                Game = Fakes.Game(),
                Name = "Powyżej 80.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                },
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 21,
                }
            };
            var evaluator = new TotalPointsFirstHalfEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void TotalPointsFirstHalfEvaluator_ShouldReturnFail_WhenMoreThanBetAndLessPointsScoredInFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalf
                },
                Game = Fakes.Game(),
                Name = "Powyżej 80.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                },
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                }
            };
            var evaluator = new TotalPointsFirstHalfEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void TotalPointsFirstHalfEvaluator_ShouldReturnSuccess_WhenLessThanBetAndLessPointsScoredInFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalf
                },
                Game = Fakes.Game(),
                Name = "Poniżej 80.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                },
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                }
            };
            var evaluator = new TotalPointsFirstHalfEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }


        [Fact]
        public void TotalPointsFirstHalfEvaluator_ShouldReturnFail_WhenLessThanBetAndMorePointsScoredInFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalf
                },
                Game = Fakes.Game(),
                Name = "Poniżej 80.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                },
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 21,
                }
            };
            var evaluator = new TotalPointsFirstHalfEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}