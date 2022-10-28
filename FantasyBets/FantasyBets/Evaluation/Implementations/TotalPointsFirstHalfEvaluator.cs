using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public class TotalPointsFirstHalfEvaluator : TotalStatsItemBaseEvaluator
    {
        public TotalPointsFirstHalfEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.TotalPointsFirstHalf;

        protected override int GetStatsItem(GameStats gameStats)
            => gameStats.ScoreHomeTeamByQuarter.Quarter1 + gameStats.ScoreHomeTeamByQuarter.Quarter2
             + gameStats.ScoreAwayTeamByQuarter.Quarter1 + gameStats.ScoreAwayTeamByQuarter.Quarter2;
    }
}
