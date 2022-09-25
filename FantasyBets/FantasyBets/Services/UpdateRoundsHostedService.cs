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
