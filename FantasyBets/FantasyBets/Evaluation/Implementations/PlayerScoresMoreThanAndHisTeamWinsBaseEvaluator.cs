using FantasyBets.Data;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation.Implementations
{
    public abstract class PlayerScoresMoreThanAndHisTeamWinsBaseEvaluator : BaseEvaluator
    {
        public PlayerScoresMoreThanAndHisTeamWinsBaseEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public abstract int PointsThreshold { get; }

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var statsLine = EvaluationHelpers.GetPlayerStats(gameStats, betSelection.Name);
            if (statsLine is null)
                return BetResult.Cancelled;

            if (statsLine.Points >= PointsThreshold)
            {
                var team = statsLine.TeamName;
                var playerIsFromHomeTeam = gameStats.ScoreHomeTeamByQuarter.Team == team;

                if ((playerIsFromHomeTeam && gameStats.ScoreHomeTeam > gameStats.ScoreAwayTeam)
                    || (!playerIsFromHomeTeam && gameStats.ScoreHomeTeam < gameStats.ScoreAwayTeam))
                {
                    return BetResult.Success;
                }
            }

            return BetResult.Fail;
        }
    }
}
