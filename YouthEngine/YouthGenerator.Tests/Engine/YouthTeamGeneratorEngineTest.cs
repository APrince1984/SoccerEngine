using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using YouthGenerator.Data;
using YouthGenerator.Engine;
using YouthGenerator.Utils;

namespace YouthGenerator.Tests.Engine
{
    [TestFixture]
    public class YouthTeamGeneratorEngineTest
    {
        [Test]
        public void CreateAllPlayersInAssembly_ReturnsListOfPlayers()
        {
            var squadAssembly = new Dictionary<int, int>
            {
                {Position.Goaly, 2},
                {Position.Defence, 3},
                {Position.Midfield, 3},
                {Position.Forward, 2},
            };
            var players = SquadGenerator.CreateAllPlayersInAssembly(squadAssembly, RandomUtil.GetRandomInt(5, 125));
            Assert.IsNotEmpty(players);
            Assert.AreEqual(10, players.Count);
            Assert.AreEqual(2, players.Count(p => p.MainPosition == Position.Goaly));
            Assert.AreEqual(3, players.Count(p => p.MainPosition == Position.Defence));
            Assert.AreEqual(3, players.Count(p => p.MainPosition == Position.Midfield));
            Assert.AreEqual(2, players.Count(p => p.MainPosition == Position.Forward));
        }

        [Test]
        public void FillSquadAssemblyUntilSquadExistsOfAtLeast20Players_SquadHasLessThen20players_PlayersAreAdded()
        {
            var squadAssembly = new Dictionary<int, int>
            {
                {Position.Goaly, 1},
                {Position.Defence, 3},
                {Position.Midfield, 3},
                {Position.Forward, 2},
            };
            SquadGenerator.FillSquadAssemblyUntilSquadExistsOfAtLeast20Players(squadAssembly);
            var numberOfPlayers = CountNumberOfPlayersInSquadAssembly(squadAssembly);

            Assert.AreEqual(20, numberOfPlayers);
        }

        private static int CountNumberOfPlayersInSquadAssembly(Dictionary<int, int> squadAssembly)
        {
            var numberOfPlayers = 0;
            foreach (var assembly in squadAssembly)
                numberOfPlayers += assembly.Value;
            return numberOfPlayers;
        }

        [Test]
        public void FillSquadAssemblyUntilSquadExistsOfAtLeast20Players_SquadHasMoreThen20players_NoPlayersAdded()
        {
            var squadAssembly = new Dictionary<int, int>
            {
                {Position.Goaly, 5},
                {Position.Defence, 5},
                {Position.Midfield, 5},
                {Position.Forward, 6},
            };
            SquadGenerator.FillSquadAssemblyUntilSquadExistsOfAtLeast20Players(squadAssembly);
            var numberOfPlayers = CountNumberOfPlayersInSquadAssembly(squadAssembly);

            Assert.AreEqual(21, numberOfPlayers);
        }

        [Test]
        public void CountNumberOfPlayers_ReturnsNumberOfPlayersInSquadAssembly()
        {
            var squadAssembly = new Dictionary<int, int>
            {
                {Position.Goaly, 5},
                {Position.Defence, 5},
                {Position.Midfield, 0},
                {Position.Forward, 5},
            };
            Assert.AreEqual(15, SquadGenerator.CountNumberOfPlayers(squadAssembly));
        }

        [Test]
        public void BuildSquadAssembly_ReturnsSquadAssembly()
        {
            var squadAssembly = SquadGenerator.BuildSquadAssembly();
            Assert.IsNotEmpty(squadAssembly);
            Assert.GreaterOrEqual(squadAssembly[Position.Goaly], 2);
            Assert.GreaterOrEqual(squadAssembly[Position.Defence], 5);
            Assert.GreaterOrEqual(squadAssembly[Position.Midfield], 5);
            Assert.GreaterOrEqual(squadAssembly[Position.Forward], 3);
            Assert.LessOrEqual(squadAssembly[Position.Goaly], 3);
            Assert.LessOrEqual(squadAssembly[Position.Defence], 7);
            Assert.LessOrEqual(squadAssembly[Position.Midfield], 7);
            Assert.LessOrEqual(squadAssembly[Position.Forward], 4);
        }

        [Test]
        public void GenerateYouthTeam_ReturnsListOfPlayersContainingAtLeast20Players()
        {
            var players = SquadGenerator.GenerateYouthTeam(RandomUtil.GetRandomInt(1, 5), RandomUtil.GetRandomInt(1, 5), RandomUtil.GetRandomInt(1, 5));
            Assert.IsNotEmpty(players);
            Assert.GreaterOrEqual(players.Count, 20);
            Assert.GreaterOrEqual(players.Count(p => p.MainPosition == Position.Goaly), 2);
            Assert.GreaterOrEqual(players.Count(p => p.MainPosition == Position.Defence), 5);
            Assert.GreaterOrEqual(players.Count(p => p.MainPosition == Position.Midfield), 5);
            Assert.GreaterOrEqual(players.Count(p => p.MainPosition == Position.Forward), 3);
        }
    }
}
