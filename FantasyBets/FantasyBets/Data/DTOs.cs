using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBets.Data
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Symbol { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Team Hosts { get; set; } = null!;
        public Team Guests { get; set; } = null!;
        public DateTime Time { get; set; }
        public int ScoreHosts { get; set; }
        public int ScoreGuests { get; set; }
    }

    public class Round
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        ICollection<Game> Games { get; set; } = null!;
    }

    public class Season
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Symbol { get; set; } = null!;
        ICollection<Round> Rounds { get; set; } = null!;
    }

    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; } = null!;

    }

    public class Odds
    {

    }
}
