using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class Total3PointersMadeByHomeTeamEvaluator : TotalStatsItemBaseEvaluator
    {
        public Total3PointersMadeByHomeTeamEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.Total3PointersMadeByHomeTeam;

        protected override int GetStatsItem(GameStats gameStats)
            => gameStats.HomeTeamStats.FieldGoalsMade3;
    }
}
