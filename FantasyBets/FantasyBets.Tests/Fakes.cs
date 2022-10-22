using FantasyBets.Data;

namespace FantasyBets.Tests
{
    internal class Fakes
    {
        public static Configuration Configuration() 
            => new Configuration
            {
                BettingFeedTeamNames = new Dictionary<string, string>
                {
                    { "RMB", "Real Madrid" },
                    { "BAR", "Barcelona" },
                    { "OLY", "Olympiacos" },
                    { "PAO", "Panathinaikos" },
                }
            };

        public static Game Game()
            => new Game
            {
                HomeTeam = new Team
                {
                    Symbol = "BAR",
                    Name = "Barcelona"
                },
                AwayTeam = new Team
                {
                    Symbol = "RMB",
                    Name = "Real Madrid"
                }
            };
    }
}
