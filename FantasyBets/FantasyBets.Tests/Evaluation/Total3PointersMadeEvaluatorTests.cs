namespace FantasyBets.Tests.Evaluation
{
    public class Total3PointersMadeEvaluatorTests
    {
        [Fact]
        public void Total3PointersEvaluator_ShouldReturnSuccess_WhenMoreThanBetAndMore3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMade
                },
                Game = Fakes.Game(),
                Name = "Powyżej 18.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                AwayTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 10,
                },
                HomeTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 9
                }

            };
            var evaluator = new Total3PointersMadeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Total3PointersEvaluator_ShouldReturnFail_WhenMoreThanBetAndLess3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMade
                },
                Game = Fakes.Game(),
                Name = "Powyżej 18.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                AwayTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 9,
                },
                HomeTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 9
                }

            };
            var evaluator = new Total3PointersMadeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }


        [Fact]
        public void Total3PointersEvaluator_ShouldReturnSuccess_WhenLessThanBetAndLess3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMade
                },
                Game = Fakes.Game(),
                Name = "Poniżej 18.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                AwayTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 9,
                },
                HomeTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 9
                }

            };
            var evaluator = new Total3PointersMadeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Total3PointersEvaluator_ShouldReturnFail_WhenLessThanBetAndMore3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMade
                },
                Game = Fakes.Game(),
                Name = "Poniżej 18.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                AwayTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 10,
                },
                HomeTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 9
                }

            };
            var evaluator = new Total3PointersMadeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

    }
}
