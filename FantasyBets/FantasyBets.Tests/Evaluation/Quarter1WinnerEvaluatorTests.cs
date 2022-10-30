namespace FantasyBets.Tests.Evaluation
{
    public class Quarter1WinnerEvaluatorTests
    {
        [Fact]
        public void Quarter1WinnerEvaluator_ShouldReturnSuccess_WhenHomeTeamBetAndWonQuarter1()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner1Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 25
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 20
                }
            };
            var evaluator = new Quarter1WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Quarter1WinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndLostQuarter1()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner1Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 22
                }
            };
            var evaluator = new Quarter1WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter1WinnerEvaluator_ShouldReturnSuccess_WhenAwayTeamBetAndWonQuarter1()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner1Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 22
                }
            };
            var evaluator = new Quarter1WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Quarter1WinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndLostQuarter1()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner1Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 24
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 20
                }
            };
            var evaluator = new Quarter1WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter1WinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndQuarter1Drawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner1Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 23
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 23
                }
            };
            var evaluator = new Quarter1WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter1WinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndQuarter1Drawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner1Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 24
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 24
                }
            };
            var evaluator = new Quarter1WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
