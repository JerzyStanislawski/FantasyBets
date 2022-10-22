using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;

namespace FantasyBets.Evaluation
{
    public abstract class BaseEvaluator
    {
        protected readonly Configuration _configuration;

        public abstract BetCode BetCode { get; }
        protected abstract BetResult EvaluateInternal(BetSelection betSelection, GameStats gameStats);

        public BaseEvaluator(Configuration configuration)
        {
            _configuration = configuration;
        }

        public  BetResult Evaluate(BetSelection betSelection, GameStats gameStats)
        {
            if (betSelection.BetType.BetCode != BetCode)
                throw new ArgumentException($"Improper bet type - {betSelection.BetType.BetCode}");

            if (gameStats.IsLive)
                return BetResult.Pending;

            return EvaluateInternal(betSelection, gameStats);
        }

        protected bool HomeTeamBet(Game game, string teamName)
            => String.Equals(_configuration.BettingFeedTeamNames[game.HomeTeam.Symbol], teamName, StringComparison.OrdinalIgnoreCase);

        protected bool AwayTeamBet(Game game, string teamName)
            => String.Equals(_configuration.BettingFeedTeamNames[game.AwayTeam.Symbol], teamName, StringComparison.OrdinalIgnoreCase);
    }
}
