using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Generators.AssemblyGenerators;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Tests.Generators.AssemblyGenerators
{
    [TestFixture]
    public class SquadAssemblyGeneratorStrategyTest
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
            var players = AssemblyGeneratorBase<Player>.CreateAllPersonsInAssembly(squadAssembly, RandomUtil.GetRandomInt(5, 125), ePerson.Player);
            Assert.IsNotEmpty(players);
            Assert.AreEqual(10, players.Count);
            foreach (var element in squadAssembly)
                Assert.AreEqual(element.Value, players.Count(p => p.MainFunction == element.Key));
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
            var squadGenerator = new SquadAssemblyGeneratorStrategy();
            squadGenerator.CompleteAssembly(squadAssembly);
            var numberOfPlayers = CountNumberOfPlayersInSquadAssembly(squadAssembly);

            Assert.AreEqual(AssemblyGeneratorBase<Player>.NumberOfPersonsInAssembly, numberOfPlayers);
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
            var squadGenerator = new SquadAssemblyGeneratorStrategy();
            squadGenerator.CompleteAssembly(squadAssembly);
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
            Assert.AreEqual(15, AssemblyGeneratorBase<Player>.CountNumberOfPersonsInAssembly(squadAssembly));
        }

        [Test]
        public void BuildSquadAssembly_ReturnsSquadAssembly()
        {
            var squadGenerator = new SquadAssemblyGeneratorStrategy();
            var squadAssembly = squadGenerator.BuildAssembly();
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
        public void GenerateSquad_ReturnsListOfPlayersContainingAtLeast20Players()
        {
            var squadGenerator = new SquadAssemblyGeneratorStrategy();
            var players = squadGenerator.GenerateAssembly(ePerson.Player, RandomUtil.GetRandomInt(1, 5), RandomUtil.GetRandomInt(1, 5), RandomUtil.GetRandomInt(1, 5));
            Assert.IsNotEmpty(players);
            Assert.GreaterOrEqual(players.Count, 20);
            Assert.GreaterOrEqual(players.Count(p => p.MainFunction == Position.Goaly), 2);
            Assert.GreaterOrEqual(players.Count(p => p.MainFunction == Position.Defence), 5);
            Assert.GreaterOrEqual(players.Count(p => p.MainFunction == Position.Midfield), 5);
            Assert.GreaterOrEqual(players.Count(p => p.MainFunction == Position.Forward), 3);
        }
    }
}
