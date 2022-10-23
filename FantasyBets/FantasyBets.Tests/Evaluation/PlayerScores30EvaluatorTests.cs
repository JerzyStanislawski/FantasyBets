using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBets.Tests.Evaluation
{
    public class PlayerScores30EvaluatorTests
    {
        [Theory]
        [InlineData(30, BetResult.Success)]
        [InlineData(35, BetResult.Success)]
        [InlineData(29, BetResult.Fail)]
        public void PlayerScores30Evaluator_ShouldReturnSuccess_WhenBet30OrMore(int points, BetResult betResult)
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores30OrMore
                },
                Game = Fakes.Game(),
                Name = "J. Vesely",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
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
            var evaluator = new PlayerScores30Evaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(betResult);
        }

        [Fact]
        public void PlayerScores30Evaluator_ShouldReturnCancelled_WhenPlayerStatsNotFound()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores30OrMore
                },
                Game = Fakes.Game(),
                Name = "T. Satoransky",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
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
            var evaluator = new PlayerScores30Evaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }

        [Fact]
        public void PlayerScores30OrMoreEvaluator_ShouldReturnProperResult_WhenFullPlayerNameInBetSelectionName()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerScores30OrMore
                },
                Game = Fakes.Game(),
                Name = "Jan Vesely",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
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
            var evaluator = new PlayerScores30Evaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
