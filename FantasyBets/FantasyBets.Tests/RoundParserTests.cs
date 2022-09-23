using FakeItEasy;
using FantasyBets.Data;
using FantasyBets.Logic.Parsers;
using FluentAssertions;

namespace FantasyBets.Tests
{
    public class RoundParserTests
    {
        [Fact]
        public async Task RoundParser_ShouldParseRound_WhenDataProviderEmpty()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://feeds.incrowdsports.com/provider/euroleague-feeds/v2/competitions/E/seasons/E2022/games?teamCode=&phaseTypeCode=RS&roundNumber=1");
            var result = await response.Content.ReadAsStringAsync();

            var dataProvider = A.Fake<IDataProvider>();
            A.CallTo(() => dataProvider.GetTeamBySymbol(A<string>._)).Returns(Task.FromResult<Team?>(null));
            A.CallTo(() => dataProvider.GetSeasonByCode(A<string>._)).Returns(Task.FromResult<Season?>(null));

            var parser = new RoundParser(dataProvider);
            var round = await parser.Parse(result);

            round.Games.Count.Should().Be(9);
            round.Games.Select(g => g.HomeTeam.Symbol).Concat(round.Games.Select(g => g.AwayTeam.Symbol)).Distinct().Count().Should().Be(18);
        }

        [Fact]
        public async Task RoundParser_ShouldParseRound_WhenDataProviderReturnsTeams()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://feeds.incrowdsports.com/provider/euroleague-feeds/v2/competitions/E/seasons/E2022/games?teamCode=&phaseTypeCode=RS&roundNumber=4");
            var result = await response.Content.ReadAsStringAsync();

            var id = 100;
            var dataProvider = A.Fake<IDataProvider>();
            A.CallTo(() => dataProvider.GetTeamBySymbol(A<string>._)).ReturnsLazily(call => Task.FromResult<Team?>(new Team
            {
                Symbol = (string)call.Arguments[0]!,
                Id = id++
            }));
            var season = new Season
            {
                Code = "2020"
            };
            A.CallTo(() => dataProvider.GetSeasonByCode(A<string>._)).Returns(Task.FromResult<Season?>(season));

            var parser = new RoundParser(dataProvider);
            var round = await parser.Parse(result);

            round.Games.Count.Should().Be(9);
            round.Games.Select(g => g.HomeTeam.Symbol).Concat(round.Games.Select(g => g.AwayTeam.Symbol)).Distinct().Count().Should().Be(18);

            round.Games.Select(g => g.HomeTeam.Id).Concat(round.Games.Select(g => g.AwayTeam.Id)).All(x => x >= 100 && x <= 117).Should().BeTrue();
            round.Season.Should().Be(season);
        }

        [Fact]
        public async Task RoundParser_ShouldReturnEmptyRound_WhenNoData()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://feeds.incrowdsports.com/provider/euroleague-feeds/v2/competitions/E/seasons/E2022/games?teamCode=&phaseTypeCode=RS&roundNumber=999");
            var result = await response.Content.ReadAsStringAsync();

            var dataProvider = A.Fake<IDataProvider>();
            var parser = new RoundParser(dataProvider);
            var round = await parser.Parse(result);

            round.Games.Count.Should().Be(0);
        }
    }
}