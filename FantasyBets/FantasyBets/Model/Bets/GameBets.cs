using FantasyBets.Data;

namespace FantasyBets.Model.Bets
{
    public class GameBets
    {
        public long Id { get; set; }
        public Game Game { get; set; } = null!;
        public IEnumerable<GameBet> Bets { get; set; } = Enumerable.Empty<GameBet>();
    }

    public class GameBet
    {
        public long Id { get; set; }
        public BetCode BetCode { get; set; }
        public string Descripion { get; set; } = null!;
        public IEnumerable<IEnumerable<GameBetSelection>> Selections { get; set; } = Enumerable.Empty<IEnumerable<GameBetSelection>>();
    }

    public class GameBetSelection
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Odds { get; set; }
    }
}
