using FantasyBets.Logic.Parsers;
using FluentAssertions;

namespace FantasyBets.Tests
{
    public class RoundParserTests
    {
        [Fact]
        public async Task RoundParser_ShouldParseRound_HappyPath()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://feeds.incrowdsports.com/provider/euroleague-feeds/v2/competitions/E/seasons/E2022/games?teamCode=&phaseTypeCode=RS&roundNumber=1");
            var result = await response.Content.ReadAsStringAsync();

            var parser = new RoundParser();
            var round = parser.Parse(result);

            round.Games.Count.Should().Be(9);
        }
    }
}