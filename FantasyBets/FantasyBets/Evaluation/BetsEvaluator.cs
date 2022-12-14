using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Reflection;

namespace FantasyBets.Evaluation
{
    public class BetsEvaluator
    {
        private readonly ReadOnlyDictionary<BetCode, BaseEvaluator> _evaluators;
        private readonly IDbContextFactory<DataContext> _dbContextFactory;
        private readonly Configuration _configuration;
        private readonly ILogger<BetsEvaluator> _logger;

        public BetsEvaluator(IDbContextFactory<DataContext> dbContextFactory, Configuration configuration, ILogger<BetsEvaluator> logger)
        {
            _dbContextFactory = dbContextFactory;
            _configuration = configuration;
            _logger = logger;

            var evaluators = ScanEvaluators();
            _evaluators = new ReadOnlyDictionary<BetCode, BaseEvaluator>(evaluators);
        }

        public async Task Evaluate(IEnumerable<BetSelection> betSelections, GameStats gameStats)
        {
            foreach (var betSelection in betSelections)
            {
                _logger.LogInformation("Evaluating bet: {betId}, {betName}", betSelection.Id, betSelection.Name);
                var result = EvaluateEvent(betSelection, gameStats);
                _logger.LogInformation("Evaluation result: {result}, {betId}, {betName}", result.ToString(), betSelection.Id, betSelection.Name);

                using var dbContext = await _dbContextFactory.CreateDbContextAsync();

                dbContext.Attach(betSelection);
                betSelection.Result = result;

                await dbContext.SaveChangesAsync();
                _logger.LogInformation("Bet result stored: {betId}, {betName}", betSelection.Id, betSelection.Name);
            }
        }

        public BetResult EvaluateEvent(BetSelection betSelection, GameStats gameStats)
        {
            if (!_evaluators.TryGetValue(betSelection.BetType.BetCode, out var evaluator))
                throw new NotImplementedException($"Could not find evaluator for {betSelection.BetType.BetCode}");

            return evaluator.Evaluate(betSelection, gameStats);
        }

        private Dictionary<BetCode, BaseEvaluator> ScanEvaluators()
        {
            var result = new Dictionary<BetCode, BaseEvaluator>();

            var assembly = Assembly.GetCallingAssembly();
            var evaluatorTypes = assembly.GetTypes()
                .Where(IsEvaluatorType);

            foreach (var evaluatorType in evaluatorTypes)
            {
                var evaluatable = Activator.CreateInstance(evaluatorType, _configuration) as BaseEvaluator;
                result[evaluatable!.BetCode] = evaluatable!;
            }

            return result;
        }

        private bool IsEvaluatorType(Type type)
        {
            if (type.IsAbstract)
                return false;

            var baseType = type.BaseType;
            while (baseType != null)
            {
                if (baseType == typeof(BaseEvaluator))
                    return true;
                baseType = baseType.BaseType;
            }

            return false;
        }
    }
}
