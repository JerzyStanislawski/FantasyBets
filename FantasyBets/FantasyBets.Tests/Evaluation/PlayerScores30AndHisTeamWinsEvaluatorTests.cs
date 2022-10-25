namespace FantasyBets.Tests.Evaluation
{
    public class PlayerScores30AndHisTeamWinsEvaluatorTests
    {
        [Theory]
        [InlineData(30, 85, 80, BetResult.Success)]
        [InlineData(35, 85, 80, BetResult.Success)]
        [InlineData(29, 85, 80, BetResult.Fail)]
        [InlineData(35, 80, 85, BetResult.Fail)]
        [InlineData(29, 80, 85, BetResult.Fail)]
        public void PlayerScores30AndHisTeamWinsEvaluator_ShouldReturnSuccess_WhenBet30OrMore(int points, int homeScore, int awayScore, BetResult betResult)
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores30OrMoreAndHisTeamWins
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
            var evaluator = new PlayerScores30AndHisTeamWinsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(betResult);
        }

        [Fact]
        public void PlayerScores30AndHisTeamWinsEvaluator_ShouldReturnCancelled_WhenPlayerStatsNotFound()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores30OrMoreAndHisTeamWins
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
                            Points = 30,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerScores30AndHisTeamWinsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void PlayerScores30AndHisTeamWinsEvaluator_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores30OrMoreAndHisTeamWins
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
                            Points = 30,
                            TeamSymbol = "BAR"
                        }
                    }
                }
            };
            var evaluator = new PlayerScores30AndHisTeamWinsEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
