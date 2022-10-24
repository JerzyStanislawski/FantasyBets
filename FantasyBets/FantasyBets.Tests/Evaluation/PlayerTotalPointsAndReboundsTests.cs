namespace FantasyBets.Tests.Evaluation
{
    public class PlayerTotalPointsAndReboundsEvaluatorTests
    {
        [Fact]
        public void PlayerTotalPointsAndReboundsEvaluator_ShouldReturnSuccess_WhenBetMoreThanAndPlayerScoredMore()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndRebounds
                },
                Game = Fakes.Game(),
                Name = "J. Vesely - powyżej 16.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = 10,
                            TotalRebounds = 7,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalPointsAndReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerTotalPointsAndReboundsEvaluator_ShouldReturnFail_WhenBetMoreThanAndPlayerScoredLess()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndRebounds
                },
                Game = Fakes.Game(),
                Name = "J. Vesely - powyżej 16.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = 10,
                            TotalRebounds = 6,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalPointsAndReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerTotalPointsAndReboundsEvaluator_ShouldReturnSuccess_WhenBetLessThanAndPlayerScoredLess()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndRebounds
                },
                Game = Fakes.Game(),
                Name = "J. Vesely - poniżej 16.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = 10,
                            TotalRebounds = 6,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalPointsAndReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerTotalPointsAndReboundsEvaluator_ShouldReturnFail_WhenBetLessThanAndPlayerScoredMore()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndRebounds
                },
                Game = Fakes.Game(),
                Name = "J. Vesely - poniżej 16.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = 10,
                            TotalRebounds = 7,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalPointsAndReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerTotalPointsAndReboundsEvaluator_ShouldReturnCancelled_WhenPlayerNotFoundInGameStats()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndRebounds
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
            var evaluator = new PlayerTotalPointsAndReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void PlayerTotalPointsAndReboundsEvaluator_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndRebounds
                },
                Game = Fakes.Game(),
                Name = "Jan Vesely - powyżej 16.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = 15,
                            TotalRebounds = 12,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalPointsAndReboundsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

    }
}
