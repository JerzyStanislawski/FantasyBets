using FantasyBets.Model.Bets;
using System.Text.Json;

namespace FantasyBets.Logic.Parsers
{
    public class RoundBetsParser
    {
        public RoundBets Parse(string betsPayload)
        {
            var bets = JsonSerializer.Deserialize<RoundBets>(betsPayload, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            if (bets is null)
                throw new ArgumentNullException(nameof(betsPayload));

            return bets;
        }
    }
}
