namespace FantasyBets.Tests.Evaluation
{
    public class PlayerScores20EvaluatorTests
    {
        [Theory]
        [InlineData(20, BetResult.Success)]
        [InlineData(25, BetResult.Success)]
        [InlineData(19, BetResult.Fail)]
        public void PlayerScores20Evaluator_ShouldReturnSuccess_WhenBet20OrMore(int points, BetResult betResult)
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores20OrMore
                },
                Game = Fakes.Game(),
                Name = "J. Vesely",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = points,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerScores20Evaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(betResult);
        }

        [Fact]
        public void PlayerScores20Evaluator_ShouldReturnCancelled_WhenPlayerStatsNotFound()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores20OrMore
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = 20,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerScores20Evaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void PlayerScores20OrMoreEvaluator_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores20OrMore
                },
                Game = Fakes.Game(),
                Name = "Jan Vesely",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = 20,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerScores20Evaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
