namespace FantasyBets.Tests.Evaluation
{
    public class TotalPointsFirstHalfAwayEvaluatorTests
    {
        [Fact]
        public void TotalPointsFirstHalfAwayEvaluator_ShouldReturnSuccess_WhenMoreThanBetAndMorePointsScoredInFirstHalfAway()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalfAway
                },
                Game = Fakes.Game(),
                Name = "Powyżej 40.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 21,
                }
            };
            var evaluator = new TotalPointsFirstHalfAwayEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void TotalPointsFirstHalfAwayEvaluator_ShouldReturnFail_WhenMoreThanBetAndLessPointsScoredInFirstHalfAway()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalfAway
                },
                Game = Fakes.Game(),
                Name = "Powyżej 40.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                }
            };
            var evaluator = new TotalPointsFirstHalfAwayEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void TotalPointsFirstHalfAwayEvaluator_ShouldReturnSuccess_WhenLessThanBetAndLessPointsScoredInFirstHalfAway()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalfAway
                },
                Game = Fakes.Game(),
                Name = "Poniżej 40.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                }
            };
            var evaluator = new TotalPointsFirstHalfAwayEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }


        [Fact]
        public void TotalPointsFirstHalfAwayEvaluator_ShouldReturnFail_WhenLessThanBetAndMorePointsScoredInFirstHalfAway()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPointsFirstHalfAway
                },
                Game = Fakes.Game(),
                Name = "Poniżej 40.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 21,
                }
            };
            var evaluator = new TotalPointsFirstHalfAwayEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}