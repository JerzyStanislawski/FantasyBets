using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class Quarter2WinnerEvaluator : QuarterWinnerBaseEvaluator
    {
        public Quarter2WinnerEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.Winner2Quarter;

        protected override Func<ScoreByQuarter, int> QuarterResult =>
            score => score.Quarter2;
    }
}
