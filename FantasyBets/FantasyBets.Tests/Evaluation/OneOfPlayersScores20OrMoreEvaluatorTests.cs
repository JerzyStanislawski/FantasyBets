namespace FantasyBets.Tests.Evaluation
{
    public class OneOfPlayersScores20OrMoreEvaluatorTests
    {
        [Theory]
        [InlineData(20, 15, BetResult.Success)]
        [InlineData(25, 15, BetResult.Success)]
        [InlineData(19, 15, BetResult.Fail)]
        [InlineData(15, 20, BetResult.Success)]
        [InlineData(15, 25, BetResult.Success)]
        [InlineData(20, 20, BetResult.Success)]
        public void OneOfPlayersScores20OrMore_ShouldReturnSuccess_WhenBet20OrMore(int points1, int points2, BetResult betResult)
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.OneOfPlayersScores20OrMore
                },
                Game = Fakes.Game(),
                Name = "J. Vesely / T. Satoransky",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = points1,
                            TeamSymbol = "BAR"
                        }
                    },
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            Points = points2,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new OneOfPlayersScores20OrMoreEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(betResult);
        }

        [Fact]
        public void OneOfPlayersScores20OrMore_ShouldReturnCancelled_WhenPlayerStatsNotFound()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.OneOfPlayersScores20OrMore
                },
                Game = Fakes.Game(),
                Name = "J. Vesely / T. Satoransky",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"MIROTIC, NIKOLA", new PlayerStats
                        {
                            Points = 20,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new OneOfPlayersScores20OrMoreEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void OneOfPlayersScores20OrMore_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.OneOfPlayersScores20OrMore
                },
                Game = Fakes.Game(),
                Name = "Jan Vesely / Tomas Satoransky",
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
                    },
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            Points = 20,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new OneOfPlayersScores20OrMoreEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
