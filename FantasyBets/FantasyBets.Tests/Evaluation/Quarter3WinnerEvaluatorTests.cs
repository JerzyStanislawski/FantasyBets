namespace FantasyBets.Tests.Evaluation
{
    public class Quarter3WinnerEvaluatorTests
    {
        [Fact]
        public void Quarter3WinnerEvaluator_ShouldReturnSuccess_WhenHomeTeamBetAndWonQuarter3()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner3Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 25
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 20
                }
            };
            var evaluator = new Quarter3WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Quarter3WinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndLostQuarter3()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner3Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 22
                }
            };
            var evaluator = new Quarter3WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter3WinnerEvaluator_ShouldReturnSuccess_WhenAwayTeamBetAndWonQuarter3()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner3Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 22
                }
            };
            var evaluator = new Quarter3WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Quarter3WinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndLostQuarter3()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner3Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 24
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 20
                }
            };
            var evaluator = new Quarter3WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter3WinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndQuarter3Drawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner3Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 23
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 23
                }
            };
            var evaluator = new Quarter3WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter3WinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndQuarter3Drawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner3Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 24
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter3 = 24
                }
            };
            var evaluator = new Quarter3WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
