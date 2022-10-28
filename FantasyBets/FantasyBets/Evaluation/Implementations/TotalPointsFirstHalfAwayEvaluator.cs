using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsFirstHalfAwayEvaluator : TotalStatsItemBaseEvaluator
    {
        public TotalPointsFirstHalfAwayEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPointsFirstHalfAway;

        protected override int GetStatsItem(GameStats gameStats)
            => gameStats.ScoreAwayTeamByQuarter.Quarter1 + gameStats.ScoreAwayTeamByQuarter.Quarter2;
    }
}
