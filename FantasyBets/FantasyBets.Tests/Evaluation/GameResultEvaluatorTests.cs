using FantasyBets.Evaluation;

namespace FantasyBets.Tests.Evaluation
{
    public class GameResultEvaluatorTests
    {
        [Fact]
        public void GameResultEvaluator_ShouldReturnSuccess_WhenHomeTeamBetAndWon()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.GameResult
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 100,
                ScoreAwayTeam = 75
            };
            var evaluator = new GameResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void GameResultEvaluator_ShouldReturnFail_WhenHomeTeamBetAndLost()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.GameResult
                },
                Game = Fakes.Game(),
                Name = "Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 75,
                ScoreAwayTeam = 76
            };
            var evaluator = new GameResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void GameResultEvaluator_ShouldReturnSuccess_WhenAwayTeamBetAndWon()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.GameResult
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 75,
                ScoreAwayTeam = 76
            };
            var evaluator = new GameResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void GameResultEvaluator_ShouldReturnFail_WhenAwayTeamBetAndLost()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.GameResult
                },
                Game = Fakes.Game(),
                Name = "Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 100,
                ScoreAwayTeam = 75
            };
            var evaluator = new GameResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void GameResultEvaluator_ShouldReturnCancelled_WhenTeamUnrecognized()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.GameResult
                },
                Game = Fakes.Game(),
                Name = "Blah blah",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 100,
                ScoreAwayTeam = 75
            };
            var evaluator = new GameResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void GameResultEvaluator_ShouldReturnSuccess_WhenDrawBetAndDrawHappenedInRegulation()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.GameResult
                },
                Game = Fakes.Game(),
                Name = EvaluationConsts.Draw,
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 21,
                    Quarter2 = 22,
                    Quarter3 = 23,
                    Quarter4 = 24
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 24,
                    Quarter2 = 23,
                    Quarter3 = 22,
                    Quarter4 = 21
                },
                ScoreHomeTeam = 100,
                ScoreAwayTeam = 98
            };
            var evaluator = new GameResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void GameResultEvaluator_ShouldReturnFail_WhenDrawBetAndNoOvertime()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.GameResult
                },
                Game = Fakes.Game(),
                Name = EvaluationConsts.Draw,
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 25,
                    Quarter4 = 25
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 25,
                    Quarter4 = 23
                },
                ScoreHomeTeam = 100,
                ScoreAwayTeam = 98
            };
            var evaluator = new GameResultEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
