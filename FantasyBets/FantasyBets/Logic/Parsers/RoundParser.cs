using FantasyBets.Data;
using System.Text.Json;

namespace FantasyBets.Logic.Parsers
{
    public class RoundParser
    {
        private readonly IDataProvider _dataProvider;

        public RoundParser(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Round> Parse(string roundPayload)
        {
            var roundJson = JsonSerializer.Deserialize<RoundJson>(roundPayload, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (roundJson is null || roundJson.Data is null)
                throw new ArgumentException("Invalid round payload");
            if (roundJson?.Status != "success")
                throw new ArgumentException("Round status not successful");

            var round = new Round()
            {
                Games = new List<Game>()
            };

            if (!roundJson!.Data.Any())
                return round;

            var cet = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            foreach (var game in roundJson!.Data)
            {
                if (game is null || game.Home is null || game.Away is null)
                    throw new ArgumentException("Incorrect game format");

                round.Games.Add(new Game
                {
                    Code = game.Code,
                    Time = TimeZoneInfo.ConvertTime(game.Date, cet),
                    HomeTeam = await _dataProvider.GetTeamBySymbol(game.Home.Tla!) ?? ConvertTeam(game.Home),
                    AwayTeam = await _dataProvider.GetTeamBySymbol(game.Away.Tla!) ?? ConvertTeam(game.Away),
                }); ;
            }

            var seasons = roundJson!.Data.Select(x => x.Season).Distinct();
            if (seasons.Count() != 1)
                throw new ArgumentException("Incorrect seasons");
            var season = seasons.Single()!;
            round.Season = await _dataProvider.GetSeasonByCode(season.Code!) ?? new Data.Season
            {
                Code = season.Code!,
                Name = season.Alias!
            };

            var phase = roundJson!.Data.Select(x => x.PhaseType!.Name).Distinct();
            if (phase.Count() != 1)
                throw new ArgumentException("Incorrect phase");
            round.Phase = phase.Single()!;

            var gameRound = roundJson!.Data.Select(x => x.Round!.Round).Distinct();
            if (gameRound.Count() != 1)
                throw new ArgumentException("Incorrect phase");
            round.Number = gameRound.Single()!;
            round.StartTime = round.Games.Select(x => x.Time).Min();
            round.EndTime = round.Games.Select(x => x.Time).Max();

            return round;
        }

        private Data.Team ConvertTeam(Team team)
        {
            if (team.Tla is null || team.Name is null || team.ImageUrls is null || !team.ImageUrls.Any())
                throw new ArgumentException("Incorrect team format");

            return new Data.Team()
            {
                Name = team.Name,
                Symbol = team.Tla,
                LogoUrl = team.ImageUrls.First().Value
            };
        }

        class RoundJson
        {
            public string? Status { get; set; }
            public IEnumerable<RoundData>? Data { get; set; }
        }

        class RoundData
        {
            public PhaseType? PhaseType { get; set; }
            public Season? Season { get; set; }
            public GameRound? Round { get; set; }
            public Team? Home { get; set; }
            public Team? Away { get; set; }
            public int Code { get; set; }
            public DateTime Date { get; set; }
        }

        class Team
        {
            public string? Tla { get; set; }
            public string? Name { get; set; }
            public Dictionary<string, string>? ImageUrls { get; set; }
        }

        class PhaseType
        {
            public string? Name { get; set; }
        }

        class GameRound
        {
            public int Round { get; set; }
        }

        class Season
        {
            public string? Code { get; set; }
            public string? Alias { get; set; }

            public override bool Equals(object? obj)
            {
                return obj is Season season &&
                       Code == season.Code;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Code);
            }
        }
    }
}
