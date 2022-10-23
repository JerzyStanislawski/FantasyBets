namespace FantasyBets.Tests.Evaluation
{
    public class TotalPointsAwayTeamEvaluatorTests
    {
        [Fact]
        public void TotalPointsAwayTeamEvaluator_ShouldReturnSuccess_WhenMoreThanBetAndMorePointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsAway
                },
                Game = Fakes.Game(),
                Name = "Powyżej 80.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 80,
                ScoreAwayTeam = 81
            };
            var evaluator = new TotalPointsAwayTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void TotalPointsAwayTeamEvaluator_ShouldReturnFail_WhenLessThanBetAndMorePointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsAway
                },
                Game = Fakes.Game(),
                Name = "Poniżej 80.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 80,
                ScoreAwayTeam = 81
            };
            var evaluator = new TotalPointsAwayTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void TotalPointsAwayTeamEvaluator_ShouldReturnSuccess_WhenLessThanBetAndLessPointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsAway
                },
                Game = Fakes.Game(),
                Name = "Poniżej 79.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 80,
                ScoreAwayTeam = 79
            };
            var evaluator = new TotalPointsAwayTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }


        [Fact]
        public void TotalPointsAwayTeamEvaluator_ShouldReturnFail_WhenMoreThanBetAndLessPointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsAway
                },
                Game = Fakes.Game(),
                Name = "Powyżej 79.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 80,
                ScoreAwayTeam = 79
            };
            var evaluator = new TotalPointsAwayTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
