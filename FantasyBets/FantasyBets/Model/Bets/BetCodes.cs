using FantasyBets.Extensions;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace FantasyBets.Model.Bets
{
    public enum BetCodes
    {
        [JsonPropertyName("Bkb_Mr6")]
        Winner, // Zwycięzca meczu
        [JsonPropertyName("Bkb_Tpt")]
        TotalPoints, // Suma punktów
        [JsonPropertyName("Bkb_Mrs")]
        GameResult, // Wynik meczu
        [JsonPropertyName("Bkb_Han")]
        Handicap, // Wynik handicap
        [JsonPropertyName("Bkb_Htp")]
        TotalPointsHome, // Suma punktów gospodarzy
        [JsonPropertyName("Bkb_Atp")]
        TotalPointsAway, // Suma punktów gości
        [JsonPropertyName("Bkb_Ptp2")]
        PlayerTotalPoints, // Łączne punkty gracza
        [JsonPropertyName("Bkb_Ppf2")]
        PlayerPerformance, // Łączny wynik gracza (punkty + zbiórki + asysty)
        [JsonPropertyName("Bkb_20p")]
        PlayerScores20OrMore, // Zawodnik zdobędzie 20 lub więcej punktów
        [JsonPropertyName("Bkb_25p")]
        PlayerScores25OrMore, // Zawodnik zdobędzie 25 lub więcej punktów
        [JsonPropertyName("Bkb_30p")]
        PlayerScores30OrMore, // Zawodnik zdobędzie 30 lub więcej punktów
        [JsonPropertyName("Bkb_Tsc")]
        BestScorer, // Najlepszy strzelec
        [JsonPropertyName("Bkb_Pta2")]
        PlayerTotalAssists, // Łączna liczba asyst
        [JsonPropertyName("Bkb_Ptr2")]
        PlayerTotalRebounds, // Łączna liczba zbiórek
        [JsonPropertyName("Bkb_PnA")]
        PlayerTotalPointsAndAssists, // Punkty i Asysty Gracza
        [JsonPropertyName("Bkb_PnR")]
        PlayerTotalPointsAndRebounds, // Punkty i zbiórki gracza
        [JsonPropertyName("Bkb_20DC")]
        OneOfPlayersScores20OrMore, // Podwójna szansa gracz zdobędzie co najmniej 20pkt
        [JsonPropertyName("Bkb_25DC")]
        OneOfPlayersScores25OrMore, // Podwójna szansa gracz zdobędzie co najmniej 25pkt
        [JsonPropertyName("Bkb_Stw")]
        PlayerScres20OrMoreAndHisTeamWins, // Gracz zdobędzie 20 punktów lub więcej i jego zespół wygra
        [JsonPropertyName("Bkb_25W")]
        PlayerScres25OrMoreAndHisTeamWins, // Gracz zdobędzie 25 punktów lub więcej i jego zespół wygra
        [JsonPropertyName("Bkb_30W")]
        PlayerScres30OrMoreAndHisTeamWins, // Gracz zdobędzie 30 punktów lub więcej i jego zespół wygra
        [JsonPropertyName("Bkb_Mot")]
        Overtime, // Dogrywka (Tak/Nie)
        [JsonPropertyName("Bkb_Htf")]
        WinnerHalfAndTotal, // Połowa / Cały
        [JsonPropertyName("Bkb_3Wmg")]
        ThreeWayDifference, // Różnica zwycięstwa 3-drogowo
        [JsonPropertyName("Bkb_Htt")]
        TotalPointsFirstHalf, // Suma punktów 1. połowy
        [JsonPropertyName("Bkb_1HHo")]
        TotalPointsFirstHalfHome, // Połowa - liczba punktów gospodarzy
        [JsonPropertyName("Bkb_1HAw")]
        TotalPointsFirstHalfAway, // Połowa - liczba punktów gości
        [JsonPropertyName("Bkb_1QHo")]
        TotalPointsFirstQuarterHome, // Pierwsza kwarta - liczba punktów gospodarzy
        [JsonPropertyName("Bkb_1QAw")]
        TotalPointsFirstQuarterAway, // Suma punktów zespołu gości w pierwszej kwarcie
        [JsonPropertyName("Bkb_Poe")]
        TotalPointsEvenOrOdd, // Parzysta / nieparzysta suma punktów meczu
        [JsonPropertyName("Bkb_Hoe")]
        TotalPointsFirstHalfEvenOrOdd, // Parzysta / nieparzysta suma punktów 1. połowy
        [JsonPropertyName("Bkb_2ho")]
        TotalPointsSecondHalfEvenOrOdd, // Punkty w 2. połowie N/P
        [JsonPropertyName("Bkb_Qoe")]
        TotalPointsFirstQuarterEvenOrOdd, // Parzysta / nieparzysta suma punktów 1. kwarty
        [JsonPropertyName("Bkb_2oe")]
        TotalPointsSecondQuarterEvenOrOdd, // Punkty 2. kwarty N/P
        [JsonPropertyName("Bkb_3oe")]
        TotalPointsThirdQuarterEvenOrOdd, // Punkty 3. kwarty N/P
        [JsonPropertyName("Bkb_4oe")]
        TotalPointsFourthQuarterEvenOrOdd, // Punkty 4. kwarty N/P
        [JsonPropertyName("Bkb_WTO")] 
        WinnerAndTotalPoints, // Zwycięzca i liczba punktów"
        [JsonPropertyName("Bkb_TPB")]
        TotalPointsRange, // Łączna liczba punktów - zakres
        [JsonPropertyName("Bkb_Fhw")]
        FirstHalfWinner, // Zwycięzca połowy
        [JsonPropertyName("Bkb_6Wmg")]
        Winner6, //Różnica zwycięstwa 6-drogowo"
        [JsonPropertyName("Bkb_Hth")]
        FirstHalfWinnerHandicap, // Wynik połowy handicap"
        [JsonPropertyName("Bkb_Htr")]
        FirstHalfResult, // Wynik połowy"
        [JsonPropertyName("")]
        FirstHalfResul2t, // Wynik połowy"
    }

    public class BetCodesMap
    {
        static BetCodesMap()
        {
            var dictionary = new Dictionary<string, BetCodes>();

            foreach (var value in Enum.GetValues(typeof(BetCodes)))
            {
                var betCode = (BetCodes)value;
                var attributeValue = betCode.GetAttributeOfType<JsonPropertyNameAttribute>();
                dictionary[attributeValue!.Name] = betCode;
            }

            Map = dictionary.ToImmutableDictionary();
        }

        public static ImmutableDictionary<string, BetCodes> Map { get; }
    }
}
