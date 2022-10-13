using FantasyBets.Model.Games;
using System.Text.Json;

namespace FantasyBets.Logic.Parsers
{
    public class GameStatsParser
    {
        private readonly Configuration _configuration;

        public GameStatsParser(Configuration configuration)
        {
            _configuration = configuration;
        }

        public GameStats? Parse(string betsPayload, int roundNumber)
        {
            var jsonGameStats = JsonSerializer.Deserialize<JsonGameStats>(betsPayload, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            if (jsonGameStats == null || jsonGameStats.Live)
                return null;

            return new GameStats()
            {
                ScoreHomeTeam = jsonGameStats.EndOfQuarter[0].Quarter4,
                ScoreAwayTeam = jsonGameStats.EndOfQuarter[1].Quarter4,
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = jsonGameStats.ByQuarter[0].Quarter1,
                    Quarter2 = jsonGameStats.ByQuarter[0].Quarter2,
                    Quarter3 = jsonGameStats.ByQuarter[0].Quarter3,
                    Quarter4 = jsonGameStats.ByQuarter[0].Quarter4,
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Quarter1 = jsonGameStats.ByQuarter[1].Quarter1,
                    Quarter2 = jsonGameStats.ByQuarter[1].Quarter2,
                    Quarter3 = jsonGameStats.ByQuarter[1].Quarter3,
                    Quarter4 = jsonGameStats.ByQuarter[1].Quarter4,
                },
                PlayerStats = jsonGameStats.Stats.SelectMany(x => x.PlayersStats)
                    .ToDictionary(x => x.Player, x => new PlayerStats
                    {
                        Points = x.Points,
                        TotalRebounds = x.TotalRebounds,
                        Assists = x.Assistances,
                        Eval = x.Valuation,
                        TeamSymbol = x.Team
                    })
            };
        }

        class JsonGameStats
        {
            public bool Live { get; set; }
            public JsonQuarters[] ByQuarter { get; set; } = Array.Empty<JsonQuarters>();
            public JsonQuarters[] EndOfQuarter { get; set; } = Array.Empty<JsonQuarters>();
            public JsonStats[] Stats { get; set; } = Array.Empty<JsonStats>();
        }

        class JsonQuarters
        {
            public string Team { get; set; } = string.Empty;
            public int Quarter1 { get; set; }
            public int Quarter2 { get; set; }
            public int Quarter3 { get; set; }
            public int Quarter4 { get; set; }
        }

        class JsonStats
        {
            public string Team { get; set; } = string.Empty;
            public JsonPlayerStats[] PlayersStats { get; set; } = Array.Empty<JsonPlayerStats>();
        }

        class JsonPlayerStats
        {
            public string Player { get; set; } = string.Empty;
            public string Team { get; set; } = string.Empty;
            public int Points { get; set; }
            public int TotalRebounds { get; set; }
            public int Assistances { get; set; }
            public int Valuation { get; set; }
        }
    }
}
