using FantasyBets.Evaluation;
using FantasyBets.Logic.Parsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace FantasyBets.Tests
{
    public class CustomBetEvaluationTest
    {
        [Fact]
        public async Task EvaluationTest()
        {
            //arrange
            int gameCode = 86;

            var dbFileName = $"../../../../FantasyBets/{nameof(DataContext.FantasyDb)}.db";
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlite($"Data Source={dbFileName}");
            using var dataContext = new DataContext(builder.Options);
            var games = dataContext.Rounds!.SelectMany(x => x.Games);

            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.PlayerPerformance
                },
                Game = dataContext.Rounds!.SelectMany(x => x.Games).Include(x => x.HomeTeam).Include(x => x.AwayTeam).First(x => x.Code == gameCode),
                Name = "N. Weiler-Babb - Ponizej 14.5",
                Result = BetResult.Pending
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://live.euroleague.net/api/Boxscore?gamecode={gameCode}&seasoncode=E2022");
            var payload = await response.Content.ReadAsStringAsync();
            var gameStats = new GameStatsParser().Parse(payload);
            if (gameStats is null)
                throw new Exception("gameStats null");
          
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            //act
            var evaluator = new BetsEvaluator(null!, config.Get<Configuration>(), new LoggerFactory().CreateLogger<BetsEvaluator>());
            var result = evaluator.EvaluateEvent(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
