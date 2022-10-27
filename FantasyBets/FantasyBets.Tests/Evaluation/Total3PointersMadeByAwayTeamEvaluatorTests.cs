namespace FantasyBets.Tests.Evaluation
{
    public class Total3PointersMadeByAwayTeamEvaluatorTests
    {
        [Fact]
        public void Total3PointersMadeByAwayTeamEvaluator_ShouldReturnSuccess_WhenMoreThanBetAndMore3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMadeByAwayTeam
                },
                Game = Fakes.Game(),
                Name = "Powyżej 9.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                AwayTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 11
                }

            };
            var evaluator = new Total3PointersMadeByAwayTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Total3PointersMadeByAwayTeamEvaluator_ShouldReturnFail_WhenMoreThanBetAndLess3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMadeByAwayTeam
                },
                Game = Fakes.Game(),
                Name = "Powyżej 9.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                AwayTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 9
                }

            };
            var evaluator = new Total3PointersMadeByAwayTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }


        [Fact]
        public void Total3PointersMadeByAwayTeamEvaluator_ShouldReturnSuccess_WhenLessThanBetAndLess3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMadeByAwayTeam
                },
                Game = Fakes.Game(),
                Name = "Poniżej 9.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                AwayTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 9
                }

            };
            var evaluator = new Total3PointersMadeByAwayTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Total3PointersMadeByAwayTeamEvaluator_ShouldReturnFail_WhenLessThanBetAndMore3PointersScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Total3PointersMadeByAwayTeam
                },
                Game = Fakes.Game(),
                Name = "Poniżej 9.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                AwayTeamStats = new TeamStats
                {
                    FieldGoalsMade3 = 12
                }

            };
            var evaluator = new Total3PointersMadeByAwayTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

    }
}
