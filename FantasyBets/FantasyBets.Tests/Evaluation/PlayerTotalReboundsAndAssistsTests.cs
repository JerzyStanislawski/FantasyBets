namespace FantasyBets.Tests.Evaluation
{
    public class PlayerTotalReboundsAndAssistsEvaluatorTests
    {
        [Fact]
        public void PlayerTotalReboundsAndAssistsEvaluator_ShouldReturnSuccess_WhenBetMoreThanAndPlayerScoredMore()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalReboundsAndAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - powyżej 12.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            TotalRebounds = 6,
                            Assists = 7,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalReboundsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerTotalReboundsAndAssistsEvaluator_ShouldReturnFail_WhenBetMoreThanAndPlayerScoredLess()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalReboundsAndAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - powyżej 12.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            TotalRebounds = 6,
                            Assists = 6,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalReboundsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerTotalReboundsAndAssistsEvaluator_ShouldReturnSuccess_WhenBetLessThanAndPlayerScoredLess()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalReboundsAndAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - poniżej 18.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            TotalRebounds = 6,
                            Assists = 6,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalReboundsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerTotalReboundsAndAssistsEvaluator_ShouldReturnFail_WhenBetLessThanAndPlayerScoredMore()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalReboundsAndAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - poniżej 12.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            TotalRebounds = 6,
                            Assists = 7,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalReboundsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerTotalReboundsAndAssistsEvaluator_ShouldReturnCancelled_WhenPlayerNotFoundInGameStats()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalReboundsAndAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - poniżej 16.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    { "VESELY, JAN", new PlayerStats() }
                }
            };
            var evaluator = new PlayerTotalReboundsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void PlayerTotalReboundsAndAssistsEvaluator_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalReboundsAndAssists
                },
                Game = Fakes.Game(),
                Name = "Tomas Satoransky - powyżej 18.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            TotalRebounds = 10,
                            Assists = 9,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalReboundsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
