namespace FantasyBets.Model.Games
{
    public class GameStats
    {
        public int ScoreHomeTeam { get; init; }
        public int ScoreAwayTeam { get; init; }
        public ScoreByQuarter ScoreHomeTeamByQuarter { get; init; } = new ScoreByQuarter();
        public ScoreByQuarter ScoreAwayTeamByQuarter { get; init; } = new ScoreByQuarter();
        public Dictionary<string, PlayerStats> PlayerStats { get; init; } = new Dictionary<string, PlayerStats>();
    }

    public class ScoreByQuarter
    {
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
    }
}
