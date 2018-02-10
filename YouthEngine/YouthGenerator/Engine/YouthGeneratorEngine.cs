using System;
using System.Collections.Generic;
using System.Linq;
using YouthGenerator.Data;
using YouthGenerator.Extensions;

namespace YouthGenerator.Engine
{
    
    public static class YouthGeneratorEngine
    {
        private static readonly Random _random = new Random();

        public static Player CreateGoaly(List<Player> youthTeam, int totalRating)
        {
            var player = new Player();
            player.MainPosition = Position.Goaly;
            player.Positions = new List<int> {PlayerPosition.Goaly};
            SetPlayerAttributes(totalRating, player);

            return player;
        }

        private static void SetPlayerAttributes(int totalRating, Player player)
        {
            player.PlayerAttributes = new Dictionary<string, int>();
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.SetGoalyAttributes(totalRating, player.MainPosition == Position.Goaly));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.SetFysicalAttributes(totalRating, IsRandomTrue()));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.SetMentalAttributes(totalRating, IsRandomTrue()));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.SetSetPiecesAttributes(totalRating, IsRandomTrue()));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.SetAttackingAttributes(totalRating, (IsRandomTrue() && player.MainPosition != Position.Goaly)));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.SetDefensiveAttributes(totalRating, player.MainPosition == Position.Defence));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.SetMidfieldAttributes(totalRating, player.MainPosition == Position.Midfield));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.SetForwardAttributes(totalRating, player.MainPosition == Position.Forward));
        }

        private static bool IsRandomTrue()
        {
            var rnd = _random.Next(1, 10);
            return rnd > 7;
        }

        

        private static Dictionary<string, int> SetAttributes()
        {
            throw new NotImplementedException();
        }
    }
}
