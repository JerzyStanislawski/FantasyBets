using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBets.Tests.Evaluation
{
    public class HandicapEvaluatorTests
    {
        [Fact]
        public void HandicapEvaluator_ShouldReturnSuccess_WhenHomeTeamBetWithNegativeHandicapAndWonByEnoughPoints()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Handicap
                },
                Game = Fakes.Game(),
                Name = "Barcelona -5.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 81,
                ScoreAwayTeam = 75
            };
            var evaluator = new HandicapEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void HandicapEvaluator_ShouldReturnFail_WhenHomeTeamBetWithNegativeHandicapAndWonByNotEnoughPoints()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Handicap
                },
                Game = Fakes.Game(),
                Name = "Barcelona -5.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 80,
                ScoreAwayTeam = 75
            };
            var evaluator = new HandicapEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void HandicapEvaluator_ShouldReturnSuccess_WhenHomeTeamBetWithPositiveHandicapAndLostByLessPoints()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Handicap
                },
                Game = Fakes.Game(),
                Name = "Barcelona +5.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 80,
                ScoreAwayTeam = 85
            };
            var evaluator = new HandicapEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void HandicapEvaluator_ShouldReturnFail_WhenHomeTeamBetWithPositiveHandicapAndLostByMorePoints()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Handicap
                },
                Game = Fakes.Game(),
                Name = "Barcelona +5.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 80,
                ScoreAwayTeam = 86
            };
            var evaluator = new HandicapEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }


        [Fact]
        public void HandicapEvaluator_ShouldReturnSuccess_WhenAwayTeamBetWithNegativeHandicapAndWonByEnoughPoints()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Handicap
                },
                Game = Fakes.Game(),
                Name = "Real Madrid -5.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 80,
                ScoreAwayTeam = 90
            };
            var evaluator = new HandicapEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void HandicapEvaluator_ShouldReturnFail_WhenAwayTeamBetWithNegativeHandicapAndLost()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Handicap
                },
                Game = Fakes.Game(),
                Name = "Real Madrid -5.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 80,
                ScoreAwayTeam = 79
            };
            var evaluator = new HandicapEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void HandicapEvaluator_ShouldReturnSuccess_WhenAwayTeamBetWithPositiveHandicapAndWon()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Handicap
                },
                Game = Fakes.Game(),
                Name = "Real Madrid +5.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 80,
                ScoreAwayTeam = 81
            };
            var evaluator = new HandicapEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void HandicapEvaluator_ShouldReturnFail_WhenAwayTeamBetWithPositiveHandicapAndLostByMorePoints()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Handicap
                },
                Game = Fakes.Game(),
                Name = "Real Madrid +5.5",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 86,
                ScoreAwayTeam = 80
            };
            var evaluator = new HandicapEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
