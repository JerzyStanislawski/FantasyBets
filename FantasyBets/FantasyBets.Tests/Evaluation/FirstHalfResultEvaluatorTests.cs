using FantasyBets.Evaluation;

namespace FantasyBets.Tests.Evaluation
{
    public class FirstHalfResultEvaluatorTests
    {
        [Fact]
        public void FirstHalfResultEvaluator_ShouldReturnSuccess_WhenHomeTeamBetAndWonFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfResult
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
            var evaluator = new FirstHalfResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void FirstHalfResultEvaluator_ShouldReturnFail_WhenHomeTeamBetAndLostFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfResult
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
            var evaluator = new FirstHalfResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void FirstHalfResultEvaluator_ShouldReturnSuccess_WhenAwayTeamBetAndWonFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfResult
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
            var evaluator = new FirstHalfResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void FirstHalfResultEvaluator_ShouldReturnFail_WhenAwayTeamBetAndLostFirstHalf()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfResult
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
            var evaluator = new FirstHalfResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void FirstHalfResultEvaluator_ShouldReturnFail_WhenAwayTeamBetAndFirstHalfDrawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfResult
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
            var evaluator = new FirstHalfResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void FirstHalfResultEvaluator_ShouldReturnFail_WhenHomeTeamBetAndFirstHalfDrawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfResult
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
            var evaluator = new FirstHalfResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void FirstHalfResultEvaluator_ShouldReturnSuccess_WhenDrawBetAndFirstHalfDrawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfResult
                },
                Game = Fakes.Game(),
                Name = EvaluationConsts.Draw,
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
            var evaluator = new FirstHalfResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void FirstHalfResultEvaluator_ShouldReturnFail_WhenDrawBetAndFirstHalfNotDrawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.FirstHalfResult
                },
                Game = Fakes.Game(),
                Name = EvaluationConsts.Draw,
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
                    Quarter2 = 21
                }
            };
            var evaluator = new FirstHalfResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
