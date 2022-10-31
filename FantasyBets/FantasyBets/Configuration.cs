namespace FantasyBets
{
    public class Configuration
    {
        public string CurrentSeasonCode { get; set; } = null!;
        public string CurrentSeasonSymbol { get; set; } = null!;
        public Feeds Feeds { get; set; } = null!;
        public Dictionary<string, string> BettingFeedTeamNames { get; set; } = null!;
        public TimeSpan RefreshBetsFrequency { get; set; }
    }

    public class Feeds
    {
        public string Schedule { get; set; } = null!;
        public string RoundBets { get; set; } = null!;
        public string GameBets { get; set; } = null!;
        public string EuroleagueTeams { get; set; } = null!;
        public string GameStats { get; set; } = null!;
        public string GameStatsGuiPrefix { get; set; } = null!;
    }
}
