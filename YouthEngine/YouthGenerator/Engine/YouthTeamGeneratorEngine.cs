using System;
using System.Collections.Generic;
using YouthGenerator.Data;

namespace YouthGenerator.Engine
{
    public static class YouthTeamGeneratorEngine
    {
        private static List<Player> _players;
        private static Dictionary<int, int> _positions;
        private static Random _random = new Random();

        public static List<Player> GenerateYouthTeam(int countryRating, int competitionRating, int teamrating)
        {
            var totalRating = teamrating * competitionRating * countryRating;
            _players = new List<Player>();
            var squadAssembly = SquadAssembly();
            var player = new Player();
            foreach (var position in squadAssembly)
            {
                switch (position.Key)
                {
                    case Position.Goaly:
                        player = YouthGeneratorEngine.CreateGoaly(_players, totalRating);
                        break;
                    case Position.Defence:
                        break;
                    case Position.Midfield:
                        break;
                    case Position.Forward:
                        break;
                }
            }
            player.BirthDate = DateTime.Now.Date.AddYears(-(_random.Next(15, 16))).AddDays(_random.Next(-365, 365));
            return _players;
        }

        public static Dictionary<int, int> SquadAssembly()
        {
            return new Dictionary<int, int>
            {
                { Position.Goaly, _random.Next(2, 3) },
                { Position.Defence, _random.Next(5, 7) },
                { Position.Midfield, _random.Next(5, 7) },
                { Position.Forward, _random.Next(3, 4) },
            };
        }
    }
}
