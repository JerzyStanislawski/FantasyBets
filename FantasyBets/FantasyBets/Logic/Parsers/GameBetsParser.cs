using FantasyBets.Model.Bets;
using System.Text.Json.Serialization;

namespace FantasyBets.Logic.Parsers
{
    public class GameBetsParser
    {

        public async Task<GameBets> Parse(string betsPayload)
        {

        }

        class Bets
        {
            public int Id { get; set; }
            public IEnumerable<Contestant> Contestants { get; set; } = Enumerable.Empty<Contestant>();
            [JsonPropertyName("grouped_markets")]
            public IEnumerable<GroupedMarket> GroupedMarkets = Enumerable.Empty<GroupedMarket>();
        }

        class Contestant
        {
            public string Name { get; set; } = null!;
            [JsonPropertyName("short_name")]
            public string ShortName { get; set; } = null!;
        }

        class GroupedMarket
        {
            public string Name { get; set; } = null!;
            public IEnumerable<Market> Markets { get; set;} = Enumerable.Empty<Market>();
        }

        class Market
        {
            public int Id { get; set; }
            [JsonPropertyName("market_type_code")]
            public BetCodes MarketTypeCode { get; set; }
            public IEnumerable<Selection> Selections { get; set; } = Enumerable.Empty<Selection>();
        }

        public class Selection
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public decimal Odds { get; set; }
        }
    }
}
