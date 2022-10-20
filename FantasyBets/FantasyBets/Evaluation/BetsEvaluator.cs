﻿using FantasyBets.Data;
using FantasyBets.Model.Bets;
using FantasyBets.Model.Games;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Reflection;

namespace FantasyBets.Evaluation
{
    public class BetsEvaluator
    {
        private readonly ReadOnlyDictionary<BetCode, IEvaluatable> _evaluators;
        private readonly IDbContextFactory<DataContext> _dbContextFactory;

        public BetsEvaluator(IDbContextFactory<DataContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

            var evaluators = ScanEvaluators();
            _evaluators = new ReadOnlyDictionary<BetCode, IEvaluatable>(evaluators);
        }

        public async Task Evaluate(IEnumerable<BetSelection> betSelections, GameStats gameStats)
        {
            foreach (var betSelection in betSelections)
            {
                if (!_evaluators.TryGetValue(betSelection.BetType.BetCode, out var evaluator))
                    throw new NotImplementedException($"Could not find evaluator for {betSelection.BetType.BetCode}");

                betSelection.Result = evaluator.Evaluate(betSelection, gameStats);

                using var dbContext = await _dbContextFactory.CreateDbContextAsync();

                dbContext.Attach(betSelection);
                await dbContext.SaveChangesAsync();
            }
        }

        private static Dictionary<BetCode, IEvaluatable> ScanEvaluators()
        {
            var result = new Dictionary<BetCode, IEvaluatable>();

            var assembly = Assembly.GetCallingAssembly();
            var evaluatorTypes = assembly.GetTypes().Where(x => x.BaseType == typeof(IEvaluatable));

            foreach (var evaluatorType in evaluatorTypes)
            {
                var evaluatable = Activator.CreateInstance(evaluatorType) as IEvaluatable;
                result[evaluatable!.BetCode] = evaluatable!;
            }

            return result;
        }
    }
}
