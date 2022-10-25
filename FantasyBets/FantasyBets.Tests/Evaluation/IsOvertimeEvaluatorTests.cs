using FantasyBets.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBets.Tests.Evaluation
{
    public class IsOvertimeEvaluatorTests
    {
        [Fact]
        public void IsOvertimeEvaluator_ShouldReturnSuccess_WhenOvertimeBetAndScoreEqualAfter4Quarters()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Overtime
                },
                Game = Fakes.Game(),
                Name = EvaluationConsts.Yes,
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 95,
                ScoreAwayTeam = 90,
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 21,
                    Quarter3 = 22,
                    Quarter4 = 23,
                },
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 23,
                    Quarter2 = 22,
                    Quarter3 = 21,
                    Quarter4 = 20,
                }
            };
            var evaluator = new IsOvertimeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void IsOvertimeEvaluator_ShouldReturnFail_WhenOvertimeBetAndScoreNotEqualAfter4Quarters()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Overtime
                },
                Game = Fakes.Game(),
                Name = EvaluationConsts.Yes,
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 86,
                ScoreAwayTeam = 80,
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 21,
                    Quarter3 = 22,
                    Quarter4 = 23,
                },
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                    Quarter3 = 20,
                    Quarter4 = 20,
                }
            };
            var evaluator = new IsOvertimeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void IsOvertimeEvaluator_ShouldReturnFail_WhenOvertimeNotBetAndScoreEqualAfter4Quarters()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Overtime
                },
                Game = Fakes.Game(),
                Name = EvaluationConsts.No,
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 95,
                ScoreAwayTeam = 90,
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 21,
                    Quarter3 = 22,
                    Quarter4 = 23,
                },
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 23,
                    Quarter2 = 22,
                    Quarter3 = 21,
                    Quarter4 = 20,
                }
            };
            var evaluator = new IsOvertimeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void IsOvertimeEvaluator_ShouldReturnSuccess_WhenOvertimeNotBetAndScoreNotEqualAfter4Quarters()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Overtime
                },
                Game = Fakes.Game(),
                Name = EvaluationConsts.No,
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeam = 86,
                ScoreAwayTeam = 80,
                ScoreHomeTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 21,
                    Quarter3 = 22,
                    Quarter4 = 23,
                },
                ScoreAwayTeamByQuarter = new()
                {
                    Quarter1 = 20,
                    Quarter2 = 20,
                    Quarter3 = 20,
                    Quarter4 = 20,
                }
            };
            var evaluator = new IsOvertimeEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}