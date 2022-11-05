using FantasyBets.Data;

namespace FantasyBets.Extensions
{
    public static class GameExtensions
    {
        private static readonly TimeZoneInfo _cet;

        static GameExtensions()
        {
            _cet = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
        }
        public static bool Started(this Game game)
        {
            var cetNow = TimeZoneInfo.ConvertTime(DateTime.UtcNow, _cet);
            return cetNow > game.Time;
        }
    }
}
