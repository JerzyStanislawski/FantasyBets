namespace FantasyBets.Tests.Evaluation
{
    public class WinnerHalfAndTotalEvaluatorTests
    {
        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnSuccess_WhenBetHomeHomeAndGameWasHomeHome()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Barcelona / Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 25,
                    Quarter4 = 25
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 24,
                    Quarter2 = 23,
                    Quarter3 = 22,
                    Quarter4 = 21
                },
                ScoreHomeTeam = 100,
                ScoreAwayTeam = 90
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnFail_WhenBetHomeHomeAndGameWasHomeAway()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Barcelona / Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 20,
                    Quarter4 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 24,
                    Quarter2 = 23,
                    Quarter3 = 28,
                    Quarter4 = 22
                },
                ScoreHomeTeam = 90,
                ScoreAwayTeam = 97
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnFail_WhenBetHomeHomeAndGameWasDrawAway()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Barcelona / Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 20,
                    Quarter4 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 28,
                    Quarter4 = 22
                },
                ScoreHomeTeam = 90,
                ScoreAwayTeam = 100
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }


        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnSuccess_WhenBetAwayHomeAndGameWasAwayHome()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Real Madrid / Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 22,
                    Quarter2 = 22,
                    Quarter3 = 25,
                    Quarter4 = 25
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 20,
                    Quarter4 = 20
                },
                ScoreHomeTeam = 94,
                ScoreAwayTeam = 90
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnFail_WhenBetAwayHomeAndGameWasHomeHome()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Real Madrid / Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 28,
                    Quarter3 = 29,
                    Quarter4 = 21
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 20,
                    Quarter4 = 20
                },
                ScoreHomeTeam = 103,
                ScoreAwayTeam = 90
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnFail_WhenBetAwayHomeAndGameWasHomeDraw()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Real Madrid / Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 28,
                    Quarter3 = 20,
                    Quarter4 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 23,
                    Quarter4 = 20
                },
                ScoreHomeTeam = 100,
                ScoreAwayTeam = 98
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnFail_WhenBetDrawHomeAndGameWasHomeDraw()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Remis / Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 28,
                    Quarter3 = 20,
                    Quarter4 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 23,
                    Quarter4 = 20
                },
                ScoreHomeTeam = 100,
                ScoreAwayTeam = 98
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnSuccess_WhenBetDrawHomeAndGameWasDrawHome()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Remis / Barcelona",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 25,
                    Quarter4 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 23,
                    Quarter4 = 20
                },
                ScoreHomeTeam = 95,
                ScoreAwayTeam = 93
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnSuccess_WhenBetDrawDrawAndGameWasDrawDraw()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Remis / Remis",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 25,
                    Quarter4 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 25,
                    Quarter4 = 20
                },
                ScoreHomeTeam = 105,
                ScoreAwayTeam = 103
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnFail_WhenBetDrawDrawAndGameWasDrawHome()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Remis / Remis",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 27,
                    Quarter4 = 25
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 25,
                    Quarter4 = 20
                },
                ScoreHomeTeam = 102,
                ScoreAwayTeam = 95
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnSuccess_WhenBetAwayDrawAndGameWasAwayDraw()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Real Madrid / Remis",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 20,
                    Quarter3 = 20,
                    Quarter4 = 25
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 20,
                    Quarter4 = 20
                },
                ScoreHomeTeam = 102,
                ScoreAwayTeam = 95
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnFail_WhenBetAwayDrawAndGameWasHomeDraw()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Real Madrid / Remis",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 30,
                    Quarter3 = 20,
                    Quarter4 = 20
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 25,
                    Quarter4 = 20
                },
                ScoreHomeTeam = 102,
                ScoreAwayTeam = 95
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnSuccess_WhenBetAwayAwayAndGameWasAwayAway()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Real Madrid / Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 20,
                    Quarter3 = 20,
                    Quarter4 = 25
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 25,
                    Quarter4 = 25
                },
                ScoreHomeTeam = 90,
                ScoreAwayTeam = 100
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }

        [Fact]
        public void WinnerHalfAndTotalEvaluator_ShouldReturnFail_WhenBetAwayAwayAndGameWasAwayHome()
        {
            //arrange
            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.WinnerHalfAndTotal
                },
                Game = Fakes.Game(),
                Name = "Real Madrid / Real Madrid",
                Result = BetResult.Pending
            };
            var gameStats = new GameStats
            {
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 20,
                    Quarter3 = 25,
                    Quarter4 = 26
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = 25,
                    Quarter2 = 25,
                    Quarter3 = 20,
                    Quarter4 = 25
                },
                ScoreHomeTeam = 96,
                ScoreAwayTeam = 95
            };
            var evaluator = new WinnerHalfAndTotalEvaluator(Fakes.Configuration());

            //act
            var result = evaluator.Evaluate(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Fail);
        }
    }
}
