namespace FantasyBets
{
    public class Configuration
    {
        public string CurrentSeasonCode { get; set; } = null!;
        public Feeds Feeds { get; set; } = null!;
    }

    public class Feeds
    {
        public string Schedule {  get; set; } = null!;
    }
}
