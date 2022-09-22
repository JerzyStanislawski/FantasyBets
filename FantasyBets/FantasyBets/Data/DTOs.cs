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
        public ICollection<Game> Games { get; set; } = null!;
    }

    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Code { get; set; }
        public Team Home { get; set; } = null!;
        public Team Away { get; set; } = null!;
        public DateTime Time { get; set; }
        public int ScoreHome { get; set; }
        public int ScoreAway { get; set; }
        public Round Round { get; set; } = null!;
    }

    public class Round
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Number { get; set; }
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

    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

    }

    public class Odds
    {

    }
}
