namespace FantasyBets.Tests.Evaluation
{
    public class PlayerScores20AndHisTeamWinsEvaluatorTests
    {
        [Theory]
        [InlineData(20, 85, 80, BetResult.Success)]
        [InlineData(25, 85, 80, BetResult.Success)]
        [InlineData(19, 85, 80, BetResult.Fail)]
        [InlineData(25, 80, 85, BetResult.Fail)]
        [InlineData(19, 80, 85, BetResult.Fail)]
        public void PlayerScores20AndHisTeamWinsEvaluator_ShouldReturnSuccess_WhenBet20OrMore(int points, int homeScore, int awayScore, BetResult betResult)
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores20OrMoreAndHisTeamWins
                },
                Game = Fakes.Game(),
                Name = "J. Vesely",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = homeScore,
                ScoreAwayTeam = awayScore,
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = points,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerScores20AndHisTeamWinsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(betResult);
        }

        [Fact]
        public void PlayerScores20AndHisTeamWinsEvaluator_ShouldReturnCancelled_WhenPlayerStatsNotFound()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores20OrMoreAndHisTeamWins
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 90,
                ScoreAwayTeam = 80,
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {
                        "VESELY, JAN", new PlayerStats
                        {
                            Points = 20,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerScores20AndHisTeamWinsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void PlayerScores20AndHisTeamWinsEvaluator_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores20OrMoreAndHisTeamWins
                },
                Game = Fakes.Game(),
                Name = "Jan Vesely",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 90,
                ScoreAwayTeam = 80,
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats
                        {
                            Points = 20,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerScores20AndHisTeamWinsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
