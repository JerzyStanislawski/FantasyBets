using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBets.Tests.Evaluation
{
    public class BestScorerEvaluatorTests
    {
        [Fact]
        public void BestScorerEvaluator_ShouldReturnSuccess_WhenPlayerWhoScoredMostWasBet()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.BestScorer
                },
                Game = Fakes.Game(),
                Name = "Jan Vesely",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats { Points = 17 } },
                    {"SATORANSKY, TOMAS", new PlayerStats { Points = 15 } },
                    {"MUSA, DZANAN", new PlayerStats { Points = 14 } },
                    {"RODRIGUEZ, SERGIO", new PlayerStats { Points = 10 } },
                }
            };
            var evaluator = new BestScorerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void BestScorerEvaluator_ShouldReturnSuccess_WhenPlayerWhoScoredMostWasBetAndOtherPlayersScoredTheSame()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.BestScorer
                },
                Game = Fakes.Game(),
                Name = "J. Vesely",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats { Points = 17 } },
                    {"SATORANSKY, TOMAS", new PlayerStats { Points = 17 } },
                    {"MUSA, DZANAN", new PlayerStats { Points = 17 } },
                    {"RODRIGUEZ, SERGIO", new PlayerStats { Points = 10 } },
                }
            };
            var evaluator = new BestScorerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void BestScorerEvaluator_ShouldReturnFail_WhenPlayerWhoDidntScoreMostWasBet()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.BestScorer
                },
                Game = Fakes.Game(),
                Name = "J. Vesely",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"VESELY, JAN", new PlayerStats { Points = 16 } },
                    {"SATORANSKY, TOMAS", new PlayerStats { Points = 17 } },
                    {"MUSA, DZANAN", new PlayerStats { Points = 15 } },
                    {"RODRIGUEZ, SERGIO", new PlayerStats { Points = 10 } },
                }
            };
            var evaluator = new BestScorerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void BestScorerEvaluator_ShouldReturnCancelled_WhenBetPlayerWasNotFoundInStats()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.BestScorer
                },
                Game = Fakes.Game(),
                Name = "J. Vesely",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                PlayerStats = new Dictionary<string, PlayerStats>
                {
                    {"SATORANSKY, TOMAS", new PlayerStats { Points = 17 } },
                    {"MUSA, DZANAN", new PlayerStats { Points = 15 } },
                    {"RODRIGUEZ, SERGIO", new PlayerStats { Points = 10 } },
                }
            };
            var evaluator = new BestScorerEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Cancelled);
        }
    }
}
