using FakeItEasy;
using FantasyBets.Data;
using FantasyBets.Logic.Parsers;
using FluentAssertions;

namespace FantasyBets.Tests
{
    public class GameBetsParserTests
    {
        [Fact]
        public async Task GameBetsParser_ShouldParsePayload_HappyPath()
        {
            var payload = File.ReadAllText("Payloads\\betsPayload.json");
            var dataProvider = A.Fake<IDataProvider>();
            var targetGame = new Game
            {
                AwayTeam = new Team { Name = "Real Madrid", Symbol = "RMB" },
                HomeTeam = new Team { Name = "Barcelona", Symbol = "BAR" },
            };
            A.CallTo(() => dataProvider.GetGamesByRound(1))
                .Returns(Task.FromResult(new List<Game>
                {
                    targetGame,
                    new Game
                    {
                        AwayTeam = new Team { Name = "Olympiacos", Symbol = "OLY" },
                        HomeTeam = new Team { Name = "Panathinaikos", Symbol = "PAN" },
                    }
                }.AsEnumerable()));
            var config = Fakes.Configuration();

            var parser = new GameBetsParser(dataProvider, config);

            var result = await parser.Parse(payload, 1);

            result.Game.Should().Be(targetGame);
            result.Bets.Count().Should().Be(25);
            result.Bets.All(x => x.Selections.Any()).Should().BeTrue();
        }
    }
}
