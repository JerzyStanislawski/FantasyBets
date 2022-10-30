using FantasyBets.Data;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public abstract class QuarterWinnerBaseEvaluator : BaseEvaluator
    {
        public QuarterWinnerBaseEvaluator(Configuration configuration) : base(configuration)
        {
        }

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            if (HomeTeamBet(betSelection.Game, betSelection.Name))
            {
                return QuarterResult(gameStats.ScoreHomeTeamByQuarter) > QuarterResult(gameStats.ScoreAwayTeamByQuarter)
                    ? BetResult.Success
                    : BetResult.Fail;
            }
            else if (AwayTeamBet(betSelection.Game, betSelection.Name))
            {
                return QuarterResult(gameStats.ScoreHomeTeamByQuarter) < QuarterResult(gameStats.ScoreAwayTeamByQuarter)
                    ? BetResult.Success
                    : BetResult.Fail;
            }
            else
                return BetResult.Cancelled;
        }

        protected abstract Func<ScoreByQuarter, int> QuarterResult { get; }
    }
}
