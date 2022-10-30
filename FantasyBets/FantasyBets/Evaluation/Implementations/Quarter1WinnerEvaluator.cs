using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class Quarter1WinnerEvaluator : QuarterWinnerBaseEvaluator
    {
        public Quarter1WinnerEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.Winner1Quarter;

        protected override Func<ScoreByQuarter, int> QuarterResult => 
            score => score.Quarter1;
    }
}
