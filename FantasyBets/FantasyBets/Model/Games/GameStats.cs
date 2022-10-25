namespace FantasyBets.Model.Games
{
    public class GameStats
    {
        public bool IsLive { get; init; }
        public int ScoreHomeTeam { get; init; }
        public int ScoreAwayTeam { get; init; }
        public ScoreByQuarter ScoreHomeTeamByQuarter { get; init; } = new ScoreByQuarter();
        public ScoreByQuarter ScoreAwayTeamByQuarter { get; init; } = new ScoreByQuarter();
        public Dictionary<string, PlayerStats> PlayerStats { get; init; } = new Dictionary<string, PlayerStats>();
        public TeamStats HostTeamStats { get; set; } = new();
        public TeamStats AwayTeamStats { get; set; } = new();
    }

    public class ScoreByQuarter
    {
        public string Team { get; init; } = String.Empty;
        public int Quarter1 { get; init; }
        public int Quarter2 { get; init; }
        public int Quarter3 { get; init; }
        public int Quarter4 { get; init; }
    }

    public class PlayerStats
    {
        public int Points { get; init; }
        public int TotalRebounds { get; init; }
        public int Assists{ get; init; }
        public int Eval { get; init; }
        public string TeamSymbol { get; init; } = string.Empty;
        public string TeamName { get; init; } = string.Empty;
    }

    public class TeamStats
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
        public int Assists { get; set; }
        public int Steals { get; set; }
        public int Turnovers { get; set; }
        public int Blocks { get; set; }
        public int Eval { get; set; }
        public int Minutes { get; set; }
    }
}
