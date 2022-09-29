namespace FantasyBets.Model.Bets
{
    public class RoundBets
    {
        public IEnumerable<Match> Matches { get; set; } = Enumerable.Empty<Match>();
    }

    public class Match
    {
        public long Id { get; set; }
    }
}
