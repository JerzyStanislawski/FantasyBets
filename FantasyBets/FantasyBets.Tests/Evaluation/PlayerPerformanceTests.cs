namespace FantasyBets.Tests.Evaluation
{
    public class PlayerPerformanceEvaluatorTests
    {
        [Fact]
        public void PlayerPerformanceEvaluator_ShouldReturnSuccess_WhenBetMoreThanAndPlayerStatsSufficient()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerPerformance
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
                            Assists = 3,
                            TotalRebounds = 4,
                            Eval = 13,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerPerformanceEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerPerformanceEvaluator_ShouldReturnFail_WhenBetMoreThanAndPlayerStatsNotSufficient()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerPerformance
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
                            Points = 8,
                            Assists = 3,
                            TotalRebounds = 4,
                            Eval = 18,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerPerformanceEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerPerformanceEvaluator_ShouldReturnSuccess_WhenBetLessThanAndPlayerStatsNotSufficient()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerPerformance
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
                            Points = 8,
                            Assists = 3,
                            TotalRebounds = 4,
                            Eval = 18,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerPerformanceEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerPerformanceEvaluator_ShouldReturnFail_WhenBetLessThanAndPlayerStatsSufficient()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerPerformance
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
                            Assists = 3,
                            TotalRebounds = 4,
                            Eval = 18,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerPerformanceEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerPerformanceEvaluator_ShouldReturnCancelled_WhenPlayerNotFoundInGameStats()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerPerformance
                },
                Game = Fakes.Game(),
                Name = "J. Vesely - poniżej 16.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    { "SATORANSKY, T.", new PlayerStats() }
                }
            };
            var evaluator = new PlayerPerformanceEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void PlayerPerformanceEvaluator_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerPerformance
                },
                Game = Fakes.Game(),
                Name = "Jan Vesely - powyzej 16.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = 10,
                            Assists = 3,
                            TotalRebounds = 4,
                            Eval = 13,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerPerformanceEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
