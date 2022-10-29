namespace FantasyBets.Tests.Evaluation
{
    public class FirstHalfWinnerEvaluaorTests
    {
        [Fact]
        public void FirstHalfWinnerEvaluator_ShouldReturnSuccess_WhenHomeTeamBetAndWonFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfWinner
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 25,
                    Quarter2 = 23
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 20,
                    Quarter2 = 20
                }
            };
            var evaluator = new FirstHalfWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void FirstHalfWinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndLostFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfWinner
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 20,
                    Quarter2 = 23
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 20,
                    Quarter2 = 25
                }
            };
            var evaluator = new FirstHalfWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void FirstHalfWinnerEvaluator_ShouldReturnSuccess_WhenAwayTeamBetAndWonFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfWinner
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 20,
                    Quarter2 = 23
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 20,
                    Quarter2 = 25
                }
            };
            var evaluator = new FirstHalfWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void FirstHalfWinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndLostFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfWinner
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 24,
                    Quarter2 = 23
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 20,
                    Quarter2 = 25
                }
            };
            var evaluator = new FirstHalfWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void FirstHalfWinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndFirstHalfDrawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfWinner
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 24,
                    Quarter2 = 23
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 23,
                    Quarter2 = 24
                }
            };
            var evaluator = new FirstHalfWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void FirstHalfWinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndFirstHalfDrawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfWinner
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 24,
                    Quarter2 = 23
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter1 = 23,
                    Quarter2 = 24
                }
            };
            var evaluator = new FirstHalfWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
