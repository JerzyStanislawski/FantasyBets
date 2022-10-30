namespace FantasyBets.Tests.Evaluation
{
    public class Quarter4WinnerEvaluatorTests
    {
        [Fact]
        public void Quarter4WinnerEvaluator_ShouldReturnSuccess_WhenHomeTeamBetAndWonQuarter4()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner4Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 25
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 20
                }
            };
            var evaluator = new Quarter4WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Quarter4WinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndLostQuarter4()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner4Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 22
                }
            };
            var evaluator = new Quarter4WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter4WinnerEvaluator_ShouldReturnSuccess_WhenAwayTeamBetAndWonQuarter4()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner4Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 22
                }
            };
            var evaluator = new Quarter4WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void Quarter4WinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndLostQuarter4()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner4Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 24
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 20
                }
            };
            var evaluator = new Quarter4WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter4WinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndQuarter4Drawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner4Quarter
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 23
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 23
                }
            };
            var evaluator = new Quarter4WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void Quarter4WinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndQuarter4Drawn()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner4Quarter
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 24
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter()
                {
                    Quarter4 = 24
                }
            };
            var evaluator = new Quarter4WinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
