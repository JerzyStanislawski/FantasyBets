using FantasyBets.Data;
using System.Text.Json;

namespace FantasyBets.Logic.Parsers
{
    public class RoundParser
    {
        private readonly DataContext _dataContext;

        public RoundParser(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Data.Round Parse(string roundPayload)
        {
            var roundJson = JsonSerializer.Deserialize<RoundJson>(roundPayload);

            if (roundJson is null || roundJson.Data is null)
                throw new ArgumentException("Invalid round payload");
            if (roundJson?.Status != "Success")
                throw new ArgumentException("Round status not successful");

            var round = new Data.Round();
            foreach (var game in roundJson!.Data)
            {
                if (game is null || game.Home is null || game.Away is null)
                    throw new ArgumentException("Incorrect game format");

                round.Games.Add(new Game
                {
                    Code = game.Code,
                    Time = game.Date,
                    Home = ConvertTeam(game.Home),
                    Away = ConvertTeam(game.Away),
                });
            }

            var seasons = roundJson!.Data.Select(x => x.Season).Distinct();
            if (seasons.Count() != 1)
                throw new ArgumentException("Incorrect seasons");
            round.Season = new Data.Season
            {
                Code = seasons.Single()!.Code!,
                Name = seasons.Single()!.Alias!
            };

            var phase = roundJson!.Data.Select(x => x.PhaseType).Distinct();
            if (phase.Count() != 1)
                throw new ArgumentException("Incorrect phase");
            round.Phase = phase.Single()!.Name!;

            var gameRound = roundJson!.Data.Select(x => x.GameRound).Distinct();
            if (gameRound.Count() != 1)
                throw new ArgumentException("Incorrect phase");
            round.Number = gameRound.Single()!.Round!;

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
            public GameRound? GameRound { get; set; }
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
        }
    }
}
