using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsFirstHalfHomeEvaluator : TotalStatsItemBaseEvaluator
    {
        public TotalPointsFirstHalfHomeEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPointsFirstHalfHome;

        protected override int GetStatsItem(GameStats gameStats)
            => gameStats.ScoreHomeTeamByQuarter.Quarter1 + gameStats.ScoreHomeTeamByQuarter.Quarter2;
    }
}
