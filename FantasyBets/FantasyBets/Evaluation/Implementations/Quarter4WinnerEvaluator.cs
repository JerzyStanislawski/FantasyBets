using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class Quarter4WinnerEvaluator : QuarterWinnerBaseEvaluator
    {
        public Quarter4WinnerEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.Winner4Quarter;

        protected override Func<ScoreByQuarter, int> QuarterResult =>
            score => score.Quarter4;
    }
}
