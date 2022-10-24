using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class BestScorerEvaluator : BaseEvaluator
    {
        public BestScorerEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.BestScorer;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var statsLine = EvaluationHelpers.GetPlayerStats(gameStats, betSelection.Name);
            if (statsLine is null)
                return BetResult.Cancelled;

            return gameStats.PlayerStats.Max(x => x.Value.Points) == statsLine!.Points
                ? BetResult.Success
                : BetResult.Fail;
        }
    }
}
