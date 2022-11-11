﻿using FantasyBets.Evaluation;
using FantasyBets.Logic.Parsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FantasyBets.Tests
{
    public class CustomBetEvaluationTest
    {
        [Fact]
        public async Task EvaluationTest()
        {
            //arrange
            int gameCode = 56;

            var dbFileName = $"../../../../FantasyBets/{nameof(DataContext.FantasyDb)}.db";
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlite($"Data Source={dbFileName}");
            using var dataContext = new DataContext(builder.Options);

            var betSelection = new BetSelection
            {
                BetType = new BetType
                {
                    BetCode = BetCode.Winner3Quarter
                },
                Game = dataContext.Rounds!.SelectMany(x => x.Games).Include(x => x.HomeTeam).Include(x => x.AwayTeam).First(x => x.Code == gameCode),
                Name = "Olympiakos",
                Result = BetResult.Pending
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://live.euroleague.net/api/Boxscore?gamecode={gameCode}&seasoncode=E2022");
            var payload = await response.Content.ReadAsStringAsync();
            var gameStats = new GameStatsParser().Parse(payload);
            if (gameStats is null)
                throw new Exeption("gameStats null");
          
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            //act
            var evaluator = new BetsEvaluator(null!, config.Get<Configuration>());
            var result = evaluator.EvaluateEvent(betSelection, gameStats);

            //assert
            result.Should().Be(BetResult.Success);
        }
    }
}
