using FantasyBets.Model.Games;
using System.Globalization;

namespace FantasyBets.Evaluation
{
    public class EvaluationHelpers
    {
        public static TeamAndHandicap ParseTeamAndHandicap(string bet)
        {
            var spaceIndex = bet.LastIndexOf(' ');
            var team = bet.Substring(0, spaceIndex);
            var handicapString = bet.Substring(spaceIndex);
            var handicap = decimal.Parse(handicapString, new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                PositiveSign = "+",
                NegativeSign = "-"
            });

            return new TeamAndHandicap(team, handicap);
        }

        public static bool ScoreEqualInRegulationTime(GameStats gameStats)
            =>  gameStats.ScoreHomeTeamByQuarter.Quarter1 +
                gameStats.ScoreHomeTeamByQuarter.Quarter2 +
                gameStats.ScoreHomeTeamByQuarter.Quarter3 +
                gameStats.ScoreHomeTeamByQuarter.Quarter4 ==
                gameStats.ScoreAwayTeamByQuarter.Quarter1 +
                gameStats.ScoreAwayTeamByQuarter.Quarter2 +
                gameStats.ScoreAwayTeamByQuarter.Quarter3 +
                gameStats.ScoreAwayTeamByQuarter.Quarter4;

        public static Difference ParseDifference(string bet)
        {
            var parts = bet.Trim().Split(' ');
            var moreThan = String.Equals(parts[0], EvaluationConsts.MoreThan, StringComparison.InvariantCultureIgnoreCase);
            var value = decimal.Parse(parts[1], new NumberFormatInfo { NumberDecimalSeparator = "." });

            return new Difference(moreThan ? DifferenceType.MoreThan : DifferenceType.LessThan, value);
        }

        public static PlayerStats? GetPlayerStats(GameStats gameStats, string playerFromBet)
        {
            var player = playerFromBet.Trim().Split(' ');
            var playerNameOrInitial = player[0].Trim('.');
            var playerSurname = player[1];

            var statsLine = gameStats.PlayerStats.SingleOrDefault(x => IsPlayerFromStats(x.Key, playerSurname, playerNameOrInitial));
            return statsLine.Value is null ? null : statsLine.Value;
        }

        private static bool IsPlayerFromStats(string playerFromStats, string playerSurname, string playerNameOrInitial)
        {
            var parts = playerFromStats.Split(',');

            return String.Equals(parts[0].Trim(), playerSurname, StringComparison.InvariantCultureIgnoreCase)
                && parts[1].Trim().StartsWith(playerNameOrInitial.ToUpper());
        }

        public static int PointsInHalftime(ScoreByQuarter scoreByQuarter)
            => scoreByQuarter.Quarter1 + scoreByQuarter.Quarter2;
    }

    public record TeamAndHandicap(string Team, decimal Handicap);

    public record Difference(DifferenceType Type, decimal Value);

    public enum DifferenceType
    {
        MoreThan,
        LessThan
    }
}
