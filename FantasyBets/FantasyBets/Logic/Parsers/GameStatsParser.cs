using FantasyBets.Model.Games;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FantasyBets.Logic.Parsers
{
    public class GameStatsParser
    {
        public GameStats? Parse(string gamePayload)
        {
            var jsonGameStats = JsonSerializer.Deserialize<JsonGameStats>(gamePayload, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            if (jsonGameStats == null)
                return null;

            return new GameStats()
            {
                IsLive = jsonGameStats.Live,
                ScoreHomeTeam = jsonGameStats.EndOfQuarter[0].Quarter4,
                ScoreAwayTeam = jsonGameStats.EndOfQuarter[1].Quarter4,
                ScoreHomeTeamByQuarter = new ScoreByQuarter
                {
                    Team = jsonGameStats.ByQuarter[0].Team,
                    Quarter1 = jsonGameStats.ByQuarter[0].Quarter1,
                    Quarter2 = jsonGameStats.ByQuarter[0].Quarter2,
                    Quarter3 = jsonGameStats.ByQuarter[0].Quarter3,
                    Quarter4 = jsonGameStats.ByQuarter[0].Quarter4,
                },
                ScoreAwayTeamByQuarter = new ScoreByQuarter
                {
                    Team = jsonGameStats.ByQuarter[1].Team,
                    Quarter1 = jsonGameStats.ByQuarter[1].Quarter1,
                    Quarter2 = jsonGameStats.ByQuarter[1].Quarter2,
                    Quarter3 = jsonGameStats.ByQuarter[1].Quarter3,
                    Quarter4 = jsonGameStats.ByQuarter[1].Quarter4,
                },
                PlayerStats = GetPlayerStats(jsonGameStats.Stats[0])
                 .Concat(GetPlayerStats(jsonGameStats.Stats[1]))
                 .ToDictionary(x => x.Key, x => x.Value),
                HomeTeamStats = GetTeamStats(jsonGameStats.Stats[0].TeamStats),
                AwayTeamStats = GetTeamStats(jsonGameStats.Stats[1].TeamStats)
            };
        }

        private Dictionary<string, PlayerStats> GetPlayerStats(JsonStats jsonStats)
        {
            return jsonStats.PlayersStats
                    .ToDictionary(x => x.Player, x => new PlayerStats
                    {
                        Points = x.Points,
                        TotalRebounds = x.TotalRebounds,
                        Assists = x.Assistances,
                        Eval = x.Valuation,
                        TeamSymbol = x.Team,
                        TeamName = jsonStats.Team
                    });
        }

        private TeamStats GetTeamStats(JsonTeamStats teamStats)
        {
            return new TeamStats
            {
                Points = teamStats.Points,
                FieldGoalsAttempted2 = teamStats.FieldGoalsAttempted2,
                FieldGoalsMade2 = teamStats.FieldGoalsMade2,
                FieldGoalsAttempted3 = teamStats.FieldGoalsAttempted3,
                FieldGoalsMade3 = teamStats.FieldGoalsMade3,
                FreeThrowsAttempted = teamStats.FreeThrowsAttempted,
                FreeThrowsMade = teamStats.FreeThrowsMade,
                DefensiveRebounds = teamStats.DefensiveRebounds,
                OffensiveRebounds = teamStats.OffensiveRebounds,
                TotalRebounds = teamStats.TotalRebounds,
                Assists = teamStats.Assistances,
                Steals = teamStats.Steals,
                Turnovers = teamStats.Turnovers,
                Blocks = teamStats.BlocksFavour,
                Eval = teamStats.Valuation,
                Minutes = int.Parse(teamStats.Minutes[..3])
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
            [JsonPropertyName("totr")]
            public JsonTeamStats TeamStats { get; set; } = new JsonTeamStats();
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

        class JsonTeamStats
        {
            public int Points { get; set; }
            public int FieldGoalsMade2 { get; set; }
            public int FieldGoalsAttempted2 { get; set; }
            public int FieldGoalsMade3 { get; set; }
            public int FieldGoalsAttempted3 { get; set; }
            public int FreeThrowsMade { get; set; }
            public int FreeThrowsAttempted { get; set; }
            public int OffensiveRebounds { get; set; }
            public int DefensiveRebounds { get; set; }
            public int TotalRebounds { get; set; }
            public int Assistances { get; set; }
            public int Steals { get; set; }
            public int Turnovers { get; set; }
            public int BlocksFavour { get; set; }
            public int Valuation { get; set; }
            public string Minutes { get; set; } = String.Empty;
        }
    }
}
