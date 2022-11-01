using FantasyBets.Data;
using FantasyBets.Logic.Parsers;
using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Services
{
    public class UpdateRoundsHostedService : IHostedService
    {
        private readonly IDbContextFactory<DataContext> _dbContextFactory;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RoundParser _roundParser;
        private readonly Configuration _configuration;
        private readonly ILogger<UpdateRoundsHostedService> _logger;

        public UpdateRoundsHostedService(IDbContextFactory<DataContext> dbContextFactory,
            IHttpClientFactory httpClientFactory,
            RoundParser roundParser,
            Configuration configuration,
            ILogger<UpdateRoundsHostedService> logger)
        {
            _dbContextFactory = dbContextFactory;
            _httpClientFactory = httpClientFactory;
            _roundParser = roundParser;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                GlobalLock.Lock();

                using var db = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
                await db.Database.EnsureCreatedAsync();
                if (!db.Rounds!.Any())
                {
                    var i = 1;
                    while (true)
                    {
                        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

                        var round = await GetRound(i);
                        if (!round.Games.Any())
                        {                            
                            break;
                        }

                        await dbContext.Rounds!.AddAsync(round);
                        SetEntitiesState(round, dbContext);
                        await dbContext.SaveChangesAsync(cancellationToken);

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating round");
            }
            finally
            {
                GlobalLock.Unlock();
            }
        }

        private void SetEntitiesState(Round round, DataContext dbContext)
        {
            if (round.Season.Id > 0)
            {
                dbContext.Entry(round.Season).State = EntityState.Unchanged;
            }

            foreach (var team in round.Games.Select(x => x.HomeTeam).Concat(round.Games.Select(x => x.AwayTeam)))
            {
                if (team.Id > 0)
                    dbContext.Entry(team).State = EntityState.Unchanged;
            }
        }

        private async Task<Round> GetRound(int i)
        {
            var url = string.Format(_configuration.Feeds.Schedule, _configuration.CurrentSeasonCode, i);
            _logger.LogInformation($"Retrieving round {i}: {url}");

            var response = await _httpClientFactory.CreateClient().GetAsync(url);
            var roundPayload = await response.Content.ReadAsStringAsync();
            return await _roundParser.Parse(roundPayload);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
