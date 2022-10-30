namespace FantasyBets.Tests.Evaluation
{
    public class Quarter2WinnerEvaluatorTests
    {
        [Fact]
        public void Quarter2WinnerEvaluator_ShouldReturnSuccess_WhenHomeTeamBetAndWonQuarter2()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner2Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 25
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 20
                }
            };
            var evaluator = new Quarter2WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Quarter2WinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndLostQuarter2()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner2Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 22
                }
            };
            var evaluator = new Quarter2WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter2WinnerEvaluator_ShouldReturnSuccess_WhenAwayTeamBetAndWonQuarter2()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner2Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 22
                }
            };
            var evaluator = new Quarter2WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Quarter2WinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndLostQuarter2()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner2Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 24
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 20
                }
            };
            var evaluator = new Quarter2WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter2WinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndQuarter2Drawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner2Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 23
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 23
                }
            };
            var evaluator = new Quarter2WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter2WinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndQuarter2Drawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner2Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 24
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter2 = 24
                }
            };
            var evaluator = new Quarter2WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
