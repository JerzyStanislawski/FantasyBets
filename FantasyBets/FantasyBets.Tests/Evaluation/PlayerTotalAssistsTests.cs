namespace FantasyBets.Tests.Evaluation
{
    public class PlayerTotalAssistsEvaluatorTests
    {
        [Fact]
        public void PlayerTotalAssistsEvaluator_ShouldReturnSuccess_WhenBetMoreThanAndPlayerScoredMore()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - powyżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            Assists = 7,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerTotalAssistsEvaluator_ShouldReturnFail_WhenBetMoreThanAndPlayerScoredLess()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - powyżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            Assists = 6,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerTotalAssistsEvaluator_ShouldReturnSuccess_WhenBetLessThanAndPlayerScoredLess()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - poniżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            Assists = 6,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerTotalAssistsEvaluator_ShouldReturnFail_WhenBetLessThanAndPlayerScoredMore()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - poniżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            Assists = 7,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerTotalAssistsEvaluator_ShouldReturnCancelled_WhenPlayerNotFoundInGameStats()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalAssists
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
            var evaluator = new PlayerTotalAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void PlayerTotalAssistsEvaluator_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalAssists
                },
                Game = Fakes.Game(),
                Name = "Tomas Satoransky - powyżej 6.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            Assists = 9,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
