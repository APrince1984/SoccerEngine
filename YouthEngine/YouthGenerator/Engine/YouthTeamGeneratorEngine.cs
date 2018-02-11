using System.Collections.Generic;
using System.Linq;
using YouthGenerator.Data;

namespace YouthGenerator.Engine
{
    public static class YouthTeamGeneratorEngine
    {
        public static List<Player> GenerateYouthTeam(int countryRating, int competitionRating, int teamrating)
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
                    players.Add(YouthGeneratorEngine.CreatePlayer(totalRating, assembly.Key));

            //player.BirthDate = DateTime.Now.Date.AddYears(-(Rnd.Next(15, 16))).AddDays(Rnd.Next(-365, 365));
            return players;
        }

        internal static void FillSquadAssemblyUntilSquadExistsOfAtLeast20Players(Dictionary<int, int> squadAssembly)
        {
            var totalNbrOfPlayers = CountNumberOfPlayers(squadAssembly);
            while (totalNbrOfPlayers < 20)
            {
                squadAssembly[squadAssembly.Keys.ElementAt(RandomEngine.GetRandomInt(0, (squadAssembly.Count - 1)))] += 1;
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
                { Position.Goaly, RandomEngine.GetRandomInt(2, 3) },
                { Position.Defence, RandomEngine.GetRandomInt(5, 7) },
                { Position.Midfield, RandomEngine.GetRandomInt(5, 7) },
                { Position.Forward, RandomEngine.GetRandomInt(3, 4) },
            };
        }
    }
}
