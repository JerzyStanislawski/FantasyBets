using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class Quarter3WinnerEvaluator : QuarterWinnerBaseEvaluator
    {
        public Quarter3WinnerEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.Winner3Quarter;

        protected override Func<ScoreByQuarter, int> QuarterResult =>
            score => score.Quarter3;
    }
}
