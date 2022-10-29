using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class GameResultEvaluator : GameWinnerEvaluator
    {
        public GameResultEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.GameResult;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            if (betSelection.Name == EvaluationConsts.Draw)
            {
                return TotalPointsInRegulation(gameStats.ScoreHomeTeamByQuarter) == TotalPointsInRegulation(gameStats.ScoreAwayTeamByQuarter)
                    ? BetResult.Success
                    : BetResult.Fail;
            }
            else if (EvaluationHelpers.ScoreEqualInRegulationTime(gameStats))
                return BetResult.Fail;

            return base.EvaluateInternal(betSelection, gameStats);
        }

        private int TotalPointsInRegulation(ScoreByQuarter quarterScore)
            => quarterScore.Quarter1 + quarterScore.Quarter2 + quarterScore.Quarter3 + quarterScore.Quarter4;
    }
}
