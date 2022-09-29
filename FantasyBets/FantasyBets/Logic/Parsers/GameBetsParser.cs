using FantasyBets.Data;
using FantasyBets.Model.Bets;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FantasyBets.Logic.Parsers
{
    public class GameBetsParser
    {
        private readonly IDataProvider _dataProvider;
        private readonly Configuration _configuration;

        public GameBetsParser(IDataProvider dataProvider, Configuration configuration)
        {
            _dataProvider = dataProvider;
            _configuration = configuration;
        }

        public async Task<GameBets> Parse(string betsPayload, int roundNumber)
        {
            var bets = JsonSerializer.Deserialize<JsonBets>(betsPayload, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            if (bets is null)
                throw new ArgumentNullException(nameof(betsPayload));

            var gameBets = new GameBets();

            var games = await _dataProvider.GetGamesByRound(roundNumber);
            var teamNames = bets.Contestants.Select(x => x.Name);

            var game = games.FirstOrDefault(x => teamNames.Contains(_configuration.BettingFeedTeamNames[x.AwayTeam.Symbol]) &&
                teamNames.Contains(_configuration.BettingFeedTeamNames[x.HomeTeam.Symbol]));
            if (game is null)
                throw new Exception("Could not assign bets to a game");
            gameBets.Game = game;

            var marketBets = new List<GameBet>();            
            foreach (var bet in bets.GroupedMarkets.SelectMany(x => x.Markets))
            {
                marketBets.Add(new GameBet
                {
                    Id = bet.Id,
                    BetCode = bet.MarketTypeCode,
                    Selections = bet.Selections.SelectMany(x => x).Select(x => new GameBetSelection
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Odds = x.Odds
                    })
                });
            }
            gameBets.Bets = marketBets;

            return gameBets;
        }

        private class JsonBets
        {
            public long Id { get; set; }
            public IEnumerable<JsonContestant> Contestants { get; set; } = Enumerable.Empty<JsonContestant>();
            [JsonPropertyName("grouped_markets")]
            public IEnumerable<JsonGroupedMarket> GroupedMarkets { get; set; } = Enumerable.Empty<JsonGroupedMarket>();
        }

        private class JsonContestant
        {
            public string Name { get; set; } = null!;
            [JsonPropertyName("short_name")]
            public string ShortName { get; set; } = null!;
        }

        private class JsonGroupedMarket
        {
            public string Name { get; set; } = null!;
            public IEnumerable<JsonMarket> Markets { get; set;} = Enumerable.Empty<JsonMarket>();
        }

        private class JsonMarket
        {
            public long Id { get; set; }
            [JsonPropertyName("market_type_code")]
            public BetCodes MarketTypeCode { get; set; }
            public IEnumerable<IEnumerable<JsonSelection>> Selections { get; set; } = 
                Enumerable.Empty<IEnumerable<JsonSelection>>();
        }

        private class JsonSelection
        {
            public long Id { get; set; }
            public string Name { get; set; } = null!;
            public decimal Odds { get; set; }
        }
    }
}
