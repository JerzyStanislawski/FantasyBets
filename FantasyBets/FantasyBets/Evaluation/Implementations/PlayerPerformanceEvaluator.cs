using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;
using System.Globalization;

namespace FantasyBets.Evaluation.Implementations
{
    public class PlayerPerformanceEvaluator : BaseEvaluator
    {
        public PlayerPerformanceEvaluator(Configuration configuration) : base(configuration)
        {
        }

        public override BetCode BetCode => BetCode.PlayerPerformance;

        protected override BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats)
        {
            var parsed = betSelection.Name.Split('-');
            var player = parsed[0].Trim().Split(' ');
            var betExpression = parsed[1].Trim().Split(' ');

            var playerNameOrInitial = player[0].Trim('.');
            var playerSurname = player[1];
            var moreThan = String.Equals(betExpression[0], "powyżej", StringComparison.InvariantCultureIgnoreCase);
            var value = decimal.Parse(betExpression[1], new NumberFormatInfo { NumberDecimalSeparator = "."});

            var statsLine = gameStats.PlayerStats.SingleOrDefault(x => IsPlayerFromStats(x.Key, playerSurname, playerNameOrInitial));
            if (statsLine.Value is null)
                return BetResult.Cancelled;

            var statsValue = CalculateStatsValue(statsLine.Value);

            return moreThan
                ? (statsValue > value ? BetResult.Success : BetResult.Fail)
                : (statsValue < value ? BetResult.Success : BetResult.Fail);
        }

        protected virtual int CalculateStatsValue(PlayerStats stats)
            => stats.Points + stats.Assists + stats.TotalRebounds;

        private bool IsPlayerFromStats(string playerFromStats, string playerSurname, string playerNameOrInitial)
        {
            var parts = playerFromStats.Split(',');

            return String.Equals(parts[0].Trim(), playerSurname, StringComparison.InvariantCultureIgnoreCase) 
                && parts[1].Trim().StartsWith(playerNameOrInitial.ToUpper());
        }
    }
}
