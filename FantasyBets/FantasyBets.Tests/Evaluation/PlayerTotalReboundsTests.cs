namespace FantasyBets.Tests.Evaluation
{
    public class PlayerTotalReboundsEvaluatorTests
    {
        [Fact]
        public void PlayerTotalReboundsEvaluator_ShouldReturnSuccess_WhenBetMoreThanAndPlayerScoredMore()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalRebounds
                },
                Game = Fakes.Game(),
                Name = "J. Vesely - powyżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            TotalRebounds = 7,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerTotalReboundsEvaluator_ShouldReturnFail_WhenBetMoreThanAndPlayerScoredLess()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalRebounds
                },
                Game = Fakes.Game(),
                Name = "J. Vesely - powyżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            TotalRebounds = 6,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerTotalReboundsEvaluator_ShouldReturnSuccess_WhenBetLessThanAndPlayerScoredLess()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalRebounds
                },
                Game = Fakes.Game(),
                Name = "J. Vesely - poniżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            TotalRebounds = 6,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerTotalReboundsEvaluator_ShouldReturnFail_WhenBetLessThanAndPlayerScoredMore()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalRebounds
                },
                Game = Fakes.Game(),
                Name = "J. Vesely - poniżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            TotalRebounds = 7,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerTotalReboundsEvaluator_ShouldReturnCancelled_WhenPlayerNotFoundInGameStats()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalRebounds
                },
                Game = Fakes.Game(),
                Name = "J. Vesely - poniżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    { "SATORANSKY, T.", new PlayerStats() }
                }
            };
            var evaluator = new PlayerTotalReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void PlayerTotalReboundsEvaluator_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalRebounds
                },
                Game = Fakes.Game(),
                Name = "Jan Vesely - powyżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            TotalRebounds = 12,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

    }
}
