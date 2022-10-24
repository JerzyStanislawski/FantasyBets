namespace FantasyBets.Tests.Evaluation
{
    public class PlayerTotalPointsAndAssistsEvaluatorTests
    {
        [Fact]
        public void PlayerTotalPointsAndAssistsEvaluator_ShouldReturnSuccess_WhenBetMoreThanAndPlayerScoredMore()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - powyżej 18.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            Points = 12,
                            Assists = 7,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalPointsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerTotalPointsAndAssistsEvaluator_ShouldReturnFail_WhenBetMoreThanAndPlayerScoredLess()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndAssists
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky - powyżej 18.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats
                        {
                            Points = 12,
                            Assists = 6,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalPointsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerTotalPointsAndAssistsEvaluator_ShouldReturnSuccess_WhenBetLessThanAndPlayerScoredLess()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndAssists
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
                            Points = 12,
                            Assists = 6,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalPointsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void PlayerTotalPointsAndAssistsEvaluator_ShouldReturnFail_WhenBetLessThanAndPlayerScoredMore()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndAssists
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
                            Points = 12,
                            Assists = 7,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalPointsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void PlayerTotalPointsAndAssistsEvaluator_ShouldReturnCancelled_WhenPlayerNotFoundInGameStats()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndAssists
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
            var evaluator = new PlayerTotalPointsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void PlayerTotalPointsAndAssistsEvaluator_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerTotalPointsAndAssists
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
                            Points = 15,
                            Assists = 9,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerTotalPointsAndAssistsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
