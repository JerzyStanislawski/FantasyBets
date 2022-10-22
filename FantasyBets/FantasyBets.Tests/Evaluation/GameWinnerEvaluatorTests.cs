namespace FantasyBets.Tests.Evaluation
{
    public class GameWinnerEvaluatorTests
    {
        [Fact]
        public void GameWinnerEvaluator_ShouldReturnSuccess_WhenHomeTeamBetAndWon()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner
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
            var evaluator = new GameWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void GameWinnerEvaluator_ShouldReturnFail_WhenHomeTeamBetAndLost()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner
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
            var evaluator = new GameWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void GameWinnerEvaluator_ShouldReturnSuccess_WhenAwayTeamBetAndWon()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner
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
            var evaluator = new GameWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void GameWinnerEvaluator_ShouldReturnFail_WhenAwayTeamBetAndLost()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner
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
            var evaluator = new GameWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void GameWinnerEvaluator_ShouldReturnCancelled_WhenTeamUnrecognized()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner
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
            var evaluator = new GameWinnerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }
    }
}
