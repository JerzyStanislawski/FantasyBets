using System.Globalization;

namespace FantasyBets.Evaluation
{
    public class EvaluationHelpers
    {
        public static TeamAndHandicap ParseTeamAndHandicap(string bet)
        {
            var parts = bet.Split(' ');
            var handicap = decimal.Parse(parts[1], new NumberFormatInfo 
            { 
                NumberDecimalSeparator = ".",
                PositiveSign = "+",
                NegativeSign = "-"
            });

            return new TeamAndHandicap(parts[0], handicap);
        }

        public static Difference ParseDifference(string bet)
        {
            var parts = bet.Trim().Split(' ');
            var moreThan = String.Equals(parts[0], EvaluationConsts.MoreThan, StringComparison.InvariantCultureIgnoreCase);
            var value = decimal.Parse(parts[1], new NumberFormatInfo { NumberDecimalSeparator = "." });

            return new Difference(moreThan ? DifferenceType.MoreThan : DifferenceType.LessThan, value);
        }
    }

    public record TeamAndHandicap(string Team, decimal Handicap);

    public record Difference(DifferenceType Type, decimal Value);

    public enum DifferenceType
    {
        MoreThan,
        LessThan
    }
}
