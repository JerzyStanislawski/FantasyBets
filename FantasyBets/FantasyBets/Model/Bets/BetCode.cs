using FantasyBets.Extensions;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace FantasyBets.Model.Bets
{
    public enum BetCode
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
        [JsonPropertyName("Bkb_35p")]
        PlayerScores35OrMore, // Zawodnik zdobędzie 30 lub więcej punktów TODO
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
        [JsonPropertyName("Bkb_AeR")]
        PlayerTotalReboundsAndAssists, // Zbiórki i Asysty Gracza TODO
        [JsonPropertyName("BKB_3pt")]
        Total3PointersMade, // Celne Rzuty za 3 TODO
        [JsonPropertyName("BKB_h3pt")]
        Total3PointersMadeByHomeTeam, // Gospodarze - Celne rzuty za 3 punkty TODO
        [JsonPropertyName("BKB_a3pt")]
        Total3PointersMadeByAwayTeam, // Goście - Celne rzuty za 3 punkty TODO
        [JsonPropertyName("Bkb_20DC")]
        OneOfPlayersScores20OrMore, // Podwójna szansa gracz zdobędzie co najmniej 20pkt
        [JsonPropertyName("Bkb_25DC")]
        OneOfPlayersScores25OrMore, // Podwójna szansa gracz zdobędzie co najmniej 25pkt
        [JsonPropertyName("Bkb_20b")]
        BothPlayersScore20OrMore, // Obydwaj gracze zdobędą co najmniej 20 pkt
        [JsonPropertyName("Bkb_Stw")]
        PlayerScores20OrMoreAndHisTeamWins, // Gracz zdobędzie 20 punktów lub więcej i jego zespół wygra
        [JsonPropertyName("Bkb_25W")]
        PlayerScores25OrMoreAndHisTeamWins, // Gracz zdobędzie 25 punktów lub więcej i jego zespół wygra
        [JsonPropertyName("Bkb_30W")]
        PlayerScores30OrMoreAndHisTeamWins, // Gracz zdobędzie 30 punktów lub więcej i jego zespół wygra
        [JsonPropertyName("Bkb_Mot")]
        Overtime, // Dogrywka (Tak/Nie)
        [JsonPropertyName("Bkb_Htf")]
        WinnerHalfAndTotal, // Połowa / Cały
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
        [JsonPropertyName("Bkb_WTO")] 
        WinnerAndTotalPoints, // Zwycięzca i liczba punktów"
        [JsonPropertyName("Bkb_TPB")]
        TotalPointsRange, // Łączna liczba punktów - zakres
        [JsonPropertyName("Bkb_Fhw")]
        FirstHalfWinner, // Zwycięzca połowy
        [JsonPropertyName("Bkb_Hth")]
        FirstHalfWinnerHandicap, // Wynik połowy handicap"
        [JsonPropertyName("Bkb_Htr")]
        FirstHalfResult, // Wynik połowy"
        [JsonPropertyName("Bkb_1QW")]
        Winner1Quarter, // Zwycięzca 1 kwarty
        [JsonPropertyName("Bkb_2QW")]
        Winner2Quarter, // Zwycięzca 1 kwarty
        [JsonPropertyName("Bkb_3QW")]
        Winner3Quarter, // Zwycięzca 1 kwarty
        [JsonPropertyName("Bkb_4QW")]
        Winner4Quarter, // Zwycięzca 1 kwarty
    }

    public class BetCodesMap
    {
        static BetCodesMap()
        {
            var dictionary = new Dictionary<string, BetCode>();

            foreach (var value in Enum.GetValues(typeof(BetCode)))
            {
                var betCode = (BetCode)value;
                var attributeValue = betCode.GetAttributeOfType<JsonPropertyNameAttribute>();
                dictionary[attributeValue!.Name] = betCode;
            }

            Map = dictionary.ToImmutableDictionary();
        }

        public static ImmutableDictionary<string, BetCode> Map { get; }
    }
}
