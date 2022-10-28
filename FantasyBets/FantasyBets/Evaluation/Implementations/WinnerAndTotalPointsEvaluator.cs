using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class WinnerAndTotalPointsEvaluator : BaseEvaluator
    {
        public WinnerAndTotalPointsEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.WinnerAndTotalPoints;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var separatorIndex = betSelection.Name.IndexOf(" i ", StringComparison.CurrentCultureIgnoreCase);
            var teamName = betSelection.Name[..separatorIndex];
            var differenceExpression = betSelection.Name[(separatorIndex + 3)..];

            var totalPointsBet = new BetSelection
            {
                Name = differenceExpression,
                BetType = new BetType
                {
                    BetCode = BetCode.TotalPoints
                },
                Game = betSelection.Game
            };
            var totalPointsEvaluator = new TotalPointsEvaluator(_configuration);
            var totalPointsResult = totalPointsEvaluator.Evaluate(totalPointsBet, gameStats);

            if (totalPointsResult != BetResult.Success)
                return totalPointsResult;

            var gameWinnerBet = new BetSelection
            {
                Name = teamName,
                BetType = new BetType
                {
                    BetCode = BetCode.Winner
                },
                Game = betSelection.Game
            };
            var winnerEvaluator = new GameWinnerEvaluator(_configuration);
            return winnerEvaluator.Evaluate(gameWinnerBet, gameStats);
        }
    }
}
