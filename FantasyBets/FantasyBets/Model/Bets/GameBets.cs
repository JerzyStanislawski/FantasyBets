using FantasyBets.Data;

namespace FantasyBets.Model.Bets
{
    public class GameBets
    {
        public int Id { get; set; }
        public Game Game { get; set; } = null!;
    }

    public class GameBet
    {
        public int Id { get; set; }
        public BetCodes BetCode { get; set; }
        public IEnumerable<GameBetSelection> Selections { get; set; } = null!;
    }

    public class GameBetSelection
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Odds { get; set; }
    }
}
