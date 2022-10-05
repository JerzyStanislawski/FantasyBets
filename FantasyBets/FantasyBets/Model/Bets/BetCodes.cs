using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FantasyBets.Model.Bets
{
    [JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumMemberConverter))]
    public enum BetCodes
    {
        [EnumMember(Value = "Bkb_Mr6")]
        Winner, // Zwycięzca meczu
        [EnumMember(Value = "Bkb_Tpt")]
        TotalPoints, // Suma punktów
        [EnumMember(Value = "Bkb_Mrs")]
        GameResult, // Wynik meczu
        [EnumMember(Value = "Bkb_Han")]
        Handicap, // Wynik handicap
        [EnumMember(Value = "Bkb_Htp")]
        TotalPointsHome, // Suma punktów gospodarzy
        [EnumMember(Value = "Bkb_Atp")]
        TotalPointsAway, // Suma punktów gości
        [EnumMember(Value = "Bkb_Ptp2")]
        PlayerTotalPoints, // Łączne punkty gracza
        [EnumMember(Value = "Bkb_Ppf2")]
        PlayerPerformance, // Łączny wynik gracza (punkty + zbiórki + asysty)
        [EnumMember(Value = "Bkb_20p")]
        PlayerScores20OrMore, // Zawodnik zdobędzie 20 lub więcej punktów
        [EnumMember(Value = "Bkb_25p")]
        PlayerScores25OrMore, // Zawodnik zdobędzie 25 lub więcej punktów
        [EnumMember(Value = "Bkb_30p")]
        PlayerScores30OrMore, // Zawodnik zdobędzie 30 lub więcej punktów
        [EnumMember(Value = "Bkb_Tsc")]
        BestScorer, // Najlepszy strzelec
        [EnumMember(Value = "Bkb_Pta2")]
        PlayerTotalAssists, // Łączna liczba asyst
        [EnumMember(Value = "Bkb_Ptr2")]
        PlayerTotalRebounds, // Łączna liczba zbiórek
        [EnumMember(Value = "Bkb_PnA")]
        PlayerTotalPointsAndAssists, // Punkty i Asysty Gracza
        [EnumMember(Value = "Bkb_PnR")]
        PlayerTotalPointsAndRebounds, // Punkty i zbiórki gracza
        [EnumMember(Value = "Bkb_20DC")]
        OneOfPlayersScores20OrMore, // Podwójna szansa gracz zdobędzie co najmniej 20pkt
        [EnumMember(Value = "Bkb_25DC")]
        OneOfPlayersScores25OrMore, // Podwójna szansa gracz zdobędzie co najmniej 25pkt
        [EnumMember(Value = "Bkb_Stw")]
        PlayerScres20OrMoreAndHisTeamWins, // Gracz zdobędzie 20 punktów lub więcej i jego zespół wygra
        [EnumMember(Value = "Bkb_25W")]
        PlayerScres25OrMoreAndHisTeamWins, // Gracz zdobędzie 25 punktów lub więcej i jego zespół wygra
        [EnumMember(Value = "Bkb_30W")]
        PlayerScres30OrMoreAndHisTeamWins, // Gracz zdobędzie 30 punktów lub więcej i jego zespół wygra
        [EnumMember(Value = "Bkb_Mot")]
        Overtime, // Dogrywka (Tak/Nie)
        [EnumMember(Value = "Bkb_Htf")]
        WinnerHalfAndTotal, // Połowa / Cały
        [EnumMember(Value = "Bkb_3Wmg")]
        ThreeWayDifference, // Różnica zwycięstwa 3-drogowo
        [EnumMember(Value = "Bkb_Htt")]
        TotalPointsFirstHalf, // Suma punktów 1. połowy
        [EnumMember(Value = "Bkb_1HHo")]
        TotalPointsFirstHalfHome, // Połowa - liczba punktów gospodarzy
        [EnumMember(Value = "Bkb_1HAw")]
        TotalPointsFirstHalfAway, // Połowa - liczba punktów gości
        [EnumMember(Value = "Bkb_1QHo")]
        TotalPointsFirstQuarterHome, // Pierwsza kwarta - liczba punktów gospodarzy
        [EnumMember(Value = "Bkb_1QAw")]
        TotalPointsFirstQuarterAway, // Suma punktów zespołu gości w pierwszej kwarcie
        [EnumMember(Value = "Bkb_Poe")]
        TotalPointsEvenOrOdd, // Parzysta / nieparzysta suma punktów meczu
        [EnumMember(Value = "Bkb_Hoe")]
        TotalPointsFirstHalfEvenOrOdd, // Parzysta / nieparzysta suma punktów 1. połowy
        [EnumMember(Value = "Bkb_2ho")]
        TotalPointsSecondHalfEvenOrOdd, // Punkty w 2. połowie N/P
        [EnumMember(Value = "Bkb_Qoe")]
        TotalPointsFirstQuarterEvenOrOdd, // Parzysta / nieparzysta suma punktów 1. kwarty
        [EnumMember(Value = "Bkb_2oe")]
        TotalPointsSecondQuarterEvenOrOdd, // Punkty 2. kwarty N/P
        [EnumMember(Value = "Bkb_3oe")]
        TotalPointsThirdQuarterEvenOrOdd, // Punkty 3. kwarty N/P
        [EnumMember(Value = "Bkb_4oe")]
        TotalPointsFourthQuarterEvenOrOdd, // Punkty 4. kwarty N/P
        [EnumMember(Value = "Bkb_WTO")] 
        WinnerAndTotalPoints, // Zwycięzca i liczba punktów"
        [EnumMember(Value = "Bkb_TPB")]
        TotalPointsRange, // Łączna liczba punktów - zakres
        [EnumMember(Value = "Bkb_Fhw")]
        FirstHalfWinner, // Zwycięzca połowy
        [EnumMember(Value = "Bkb_6Wmg")]
        Winner6, //Różnica zwycięstwa 6-drogowo"
        [EnumMember(Value = "Bkb_Hth")]
        FirstHalfWinnerHandicap, // Wynik połowy handicap"
        [EnumMember(Value = "Bkb_Htr")]
        FirstHalfResult, // Wynik połowy"
        [EnumMember(Value = "")]
        FirstHalfResul2t, // Wynik połowy"

    }
}
