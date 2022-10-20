using FantasyBets.Model.Bets;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBets.Data
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Symbol { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
        public ICollection<Game> GamesAsHome { get; set; } = null!;
        public ICollection<Game> GamesAsAway { get; set; } = null!;
    }

    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Code { get; set; }

        [ForeignKey(nameof(HomeTeamId))]
        public Team HomeTeam { get; set; } = null!;
        public int HomeTeamId { get; set; }
        [ForeignKey(nameof(AwayTeamId))]
        public Team AwayTeam { get; set; } = null!;
        public int AwayTeamId { get; set; }

        public DateTime Time { get; set; }
        public int ScoreHome { get; set; }
        public int ScoreAway { get; set; }
        public Round Round { get; set; } = null!;
        public ICollection<BetSelection> BetSelections { get; set; } = null!;
    }

    public class Round
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsFinished { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Phase { get; set; } = null!;
        public ICollection<Game> Games { get; set; } = null!;
        public Season Season { get; set; } = null!;
    }

    public class Season
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ICollection<Round> Rounds { get; set; } = null!;
    }

    public class FantasyUser : IdentityUser
    {
        public ICollection<BetSelection> BetSelections { get; set; } = null!;
    }

    public class BetType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public BetCode BetCode { get; set; }
        public string Descripion { get; set; } = null!;
        public ICollection<BetSelection> BetSelections { get; set; } = null!;
    }

    public class BetSelection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Odds { get; set; }
        public BetType BetType { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public FantasyUser User { get; set; } = null!;
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;
        public int GameId { get; set; }

        public BetResult Result { get; set; } = BetResult.Pending;
    }

    public enum BetResult
    {
        Success,
        Fail,
        Pending,
        Cancelled
    }
}
