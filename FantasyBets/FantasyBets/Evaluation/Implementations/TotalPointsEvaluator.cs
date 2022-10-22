using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;
using System.Globalization;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsEvaluator : BaseEvaluator
    {
        public TotalPointsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPoints;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var difference = EvaluationHelpers.ParseDifference(betSelection.Name);

            var statsValue = CalculateStatsValue(gameStats);

            return difference.Type == DifferenceType.MoreThan
                ? (statsValue > difference.Value ? BetResult.Success : BetResult.Fail)
                : (statsValue < difference.Value ? BetResult.Success : BetResult.Fail);
        }

        private int CalculateStatsValue(GameStats gameStats)
            => gameStats.ScoreAwayTeam + gameStats.ScoreHomeTeam;
    }
}
