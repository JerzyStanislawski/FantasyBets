using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation
{
    public interface IEvaluatable
    {
        BetCode BetCode { get; }
        BetResult Evaluate(BetSelection betSelection, GameStats gameStats);
    }
}
