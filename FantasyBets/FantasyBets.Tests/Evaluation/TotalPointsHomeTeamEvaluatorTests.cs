namespace FantasyBets.Tests.Evaluation
{
    public class TotalPointsHomeTeamEvaluatorTests
    {
        [Fact]
        public void TotalPointsHomeTeamEvaluator_ShouldReturnSuccess_WhenMoreThanBetAndMorePointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsHome
                },
                Game = Fakes.Game(),
                Name = "Powyżej 80.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 81,
                ScoreAwayTeam = 80
            };
            var evaluator = new TotalPointsHomeTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void TotalPointsHomeTeamEvaluator_ShouldReturnFail_WhenLessThanBetAndMorePointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsHome
                },
                Game = Fakes.Game(),
                Name = "Poniżej 80.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 81,
                ScoreAwayTeam = 80
            };
            var evaluator = new TotalPointsHomeTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void TotalPointsHomeTeamEvaluator_ShouldReturnSuccess_WhenLessThanBetAndLessPointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsHome
                },
                Game = Fakes.Game(),
                Name = "Poniżej 79.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 79,
                ScoreAwayTeam = 80
            };
            var evaluator = new TotalPointsHomeTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }


        [Fact]
        public void TotalPointsHomeTeamEvaluator_ShouldReturnFail_WhenMoreThanBetAndLessPointsScored()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsHome
                },
                Game = Fakes.Game(),
                Name = "Powyżej 79.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 79,
                ScoreAwayTeam = 80
            };
            var evaluator = new TotalPointsHomeTeamEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
