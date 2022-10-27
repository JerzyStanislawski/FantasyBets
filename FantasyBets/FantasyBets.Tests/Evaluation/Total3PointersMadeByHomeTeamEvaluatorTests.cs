namespace FantasyBets.Tests.Evaluation
{
    public class Total3PointersMadeByHomeTeamEvaluatorTests
    {
        [Fact]
        public void Total3PointersMadeByHomeTeamEvaluator_ShouldReturnSuccess_WhenMoreThanBetAndMore3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMadeByHomeTeam
                },
                Game = Fakes.Game(),
                Name = "Powyżej 9.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                HomeTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 11
                }

            };
            var evaluator = new Total3PointersMadeByHomeTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Total3PointersMadeByHomeTeamEvaluator_ShouldReturnFail_WhenMoreThanBetAndLess3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMadeByHomeTeam
                },
                Game = Fakes.Game(),
                Name = "Powyżej 9.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                HomeTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 9
                }

            };
            var evaluator = new Total3PointersMadeByHomeTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }


        [Fact]
        public void Total3PointersMadeByHomeTeamEvaluator_ShouldReturnSuccess_WhenLessThanBetAndLess3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMadeByHomeTeam
                },
                Game = Fakes.Game(),
                Name = "Poniżej 9.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                HomeTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 9
                }

            };
            var evaluator = new Total3PointersMadeByHomeTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Total3PointersMadeByHomeTeamEvaluator_ShouldReturnFail_WhenLessThanBetAndMore3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMadeByHomeTeam
                },
                Game = Fakes.Game(),
                Name = "Poniżej 9.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                HomeTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 12
                }

            };
            var evaluator = new Total3PointersMadeByHomeTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

    }
}
