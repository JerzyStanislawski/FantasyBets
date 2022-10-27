using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class Total3PointersMadeEvaluator : TotalStatsItemBaseEvaluator
    {
        public Total3PointersMadeEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.Total3PointersMade;

        protected override int GetStatsItem(GameStats gameStats)
            => gameStats.HomeTeamStats.FieldGoalsMade3 + gameStats.AwayTeamStats.FieldGoalsMade3;
    }
}
