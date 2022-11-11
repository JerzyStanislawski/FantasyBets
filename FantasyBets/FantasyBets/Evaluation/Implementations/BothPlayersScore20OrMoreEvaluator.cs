using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class BothPlayersScore20OrMoreEvaluator : BaseEvaluator
    {
        public BothPlayersScore20OrMoreEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.BothPlayersScore20OrMore;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var players = betSelection.Name.Split('&');
            if (players.Count() < 2)
                players = betSelection.Name.Split('/');

            var statsLine1 = EvaluationHelpers.GetPlayerStats(gameStats, players[0].Trim());
            var statsLine2 = EvaluationHelpers.GetPlayerStats(gameStats, players[1].Trim());

            if (statsLine1 is null || statsLine2 is null)
                return BetResult.Cancelled;

            return statsLine1!.Points >= 20 && statsLine2!.Points >= 20
                ? BetResult.Success
                : BetResult.Fail;
        }
    }
}
