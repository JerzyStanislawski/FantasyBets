using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class Total3PointersMadeByAwayTeamEvaluator : TotalStatsItemBaseEvaluator
    {
        public Total3PointersMadeByAwayTeamEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.Total3PointersMadeByAwayTeam;

        protected override int GetStatsItem(GameStats gameStats)
            => gameStats.AwayTeamStats.FieldGoalsMade3;
    }
}
