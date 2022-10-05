using FantasyBets.Model.Bets;

namespace FantasyBets.Services
{
    public class BetsProvider : IBetsProvider
    {
        public List<GameBets> Bets { get; } = new List<GameBets>();
    }

    public interface IBetsProvider
    {
        List<GameBets> Bets { get; }
    }
}
