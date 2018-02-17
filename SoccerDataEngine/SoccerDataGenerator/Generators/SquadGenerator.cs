using System.Collections.Generic;
using System.Linq;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Factories;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators
{
    public static class SquadGenerator
    {
        public static List<Player> GenerateSquad(int countryRating, int competitionRating, int teamrating)
        {
            var totalRating = teamrating * competitionRating * countryRating;
            var squadAssembly = BuildSquadAssembly();
            FillSquadAssemblyUntilSquadExistsOfAtLeast20Players(squadAssembly);
            return CreateAllPlayersInAssembly(squadAssembly, totalRating);
        }

        internal static List<Player> CreateAllPlayersInAssembly(Dictionary<int, int> squadAssembly, int totalRating)
        {
            var players = new List<Player>();
            foreach (var assembly in squadAssembly)
                for (var i = 0; i < assembly.Value; i++)
                    players.Add(PersonStrategyFactory<Player>.CreatePlayer(ePerson.Player, totalRating, assembly.Key));

            return players;
        }

        internal static void FillSquadAssemblyUntilSquadExistsOfAtLeast20Players(Dictionary<int, int> squadAssembly)
        {
            var totalNbrOfPlayers = CountNumberOfPlayers(squadAssembly);
            while (totalNbrOfPlayers < 20)
            {
                squadAssembly[squadAssembly.Keys.ElementAt(RandomUtil.GetRandomInt(0, (squadAssembly.Count - 1)))] += 1;
                totalNbrOfPlayers++;
            }
        }

        internal static int CountNumberOfPlayers(Dictionary<int, int> squadAssembly)
        {
            var totalNbrOfPlayers = 0;
            foreach (var assembly in squadAssembly)
                totalNbrOfPlayers += assembly.Value;
            return totalNbrOfPlayers;
        }

        internal static Dictionary<int, int> BuildSquadAssembly()
        {
            return new Dictionary<int, int>
            {
                { Position.Goaly, RandomUtil.GetRandomInt(2, 3) },
                { Position.Defence, RandomUtil.GetRandomInt(5, 7) },
                { Position.Midfield, RandomUtil.GetRandomInt(5, 7) },
                { Position.Forward, RandomUtil.GetRandomInt(3, 4) },
            };
        }
    }
}
