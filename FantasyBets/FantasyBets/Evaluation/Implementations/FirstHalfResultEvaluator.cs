using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class FirstHalfResultEvaluator : FirstHalfWinnerEvaluator
    {
        public FirstHalfResultEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.FirstHalfResult;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            if (betSelection.Name == EvaluationConsts.Draw)
            {
                return EvaluationHelpers.PointsInHalftime(gameStats.ScoreHomeTeamByQuarter) == EvaluationHelpers.PointsInHalftime(gameStats.ScoreAwayTeamByQuarter)
                    ? BetResult.Success
                    : BetResult.Fail;
            }

            return base.EvaluateInternal(betSelection, gameStats);
        }
    }
}
