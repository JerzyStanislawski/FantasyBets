using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class WinnerHalfAndTotalEvaluator : BaseEvaluator

    {
        public WinnerHalfAndTotalEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.WinnerHalfAndTotal;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var results = betSelection.Name.Split('/'));

            var firstHalfResult = results[0].Trim();
            var secondHalfResult = results[1].Trim();
        }
    }
}
