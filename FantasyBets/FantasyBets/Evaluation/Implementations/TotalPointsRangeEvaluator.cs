using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;
using System.Globalization;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsRangeEvaluator : BaseEvaluator
    {
        public TotalPointsRangeEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPointsRange;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var totalPoints = gameStats.ScoreHomeTeam + gameStats.ScoreAwayTeam;

            if (betSelection.Name.Contains('+'))
            {
                var value = decimal.Parse(betSelection.Name.Trim('+'), new NumberFormatInfo { NumberDecimalSeparator = "." });
                return totalPoints > value
                    ? BetResult.Success
                    : BetResult.Fail;
            }

            var values = betSelection.Name.Split('-');
            var min = int.Parse(values[0].Trim());
            var max = int.Parse(values[1].Trim());

            return totalPoints >= min && totalPoints <= max
                ? BetResult.Success
                : BetResult.Fail;
        }
    }
}
