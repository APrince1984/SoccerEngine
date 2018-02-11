using System;
using System.Collections.Generic;
using System.Reflection;
using YouthGenerator.Data;
using YouthGenerator.Extensions;

namespace YouthGenerator.Engine
{
    
    public static class YouthGeneratorEngine
    {
        private static readonly Random Rnd = new Random();

        public static Player CreatePlayer(int totalRating, int mainPosition)
        {
            var player = new Player();
            player.MainPosition = mainPosition;
            SetPlayerPositionsByMainPosition(player);
            SetPlayerAttributes(totalRating, player);
            return player;
        }

        internal static void SetPlayerPositionsByMainPosition(Player player)
        {
            if (player.MainPosition == Position.Goaly)
            {
                player.Positions = new List<int> {PlayerPosition.Goaly};
                return;
            }
            
            player.Positions = new List<int>();
            var nbrOfPositions = player.MainPosition == Position.Forward ? Rnd.Next(1, 2) : Rnd.Next(1, 3);
            for (var i = 1; i <= nbrOfPositions; i++)
            {
                switch (player.MainPosition)
                {
                    case Position.Defence:
                        SetPlayerPositions(player, typeof(PlayerPosition.DefensivePositions));
                        break;
                    case Position.Midfield:
                        SetPlayerPositions(player, typeof(PlayerPosition.MidfieldPositions));
                        break;
                    default:
                        SetPlayerPositions(player, typeof(PlayerPosition.ForwardPositions));
                        break;
                }
            }
            
        }

        internal static void SetPlayerPositions(Player player, Type positionType)
        {
            var playerPositions = positionType.GetFields();
            var value = GetPlayerPositionValue(playerPositions);
            value = GetNewPlayerPositionValueIfNeeded(player, value, playerPositions);
            
            player.Positions.Add(value);
        }

        internal static int GetNewPlayerPositionValueIfNeeded(Player player, int value, FieldInfo[] playerPositions)
        {
            while (player.Positions.Contains(value))
                value = GetPlayerPositionValue(playerPositions);
            return value;
        }

        private static int GetPlayerPositionValue(FieldInfo[] playerPositions)
        {
            var index = Rnd.Next(0, playerPositions.Length);
            return (int) playerPositions[index].GetValue(playerPositions[index].Name);
        }

        internal static void SetPlayerAttributes(int totalRating, Player player)
        {
            player.PlayerAttributes = new Dictionary<string, int>();
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.AddPlayerAttributesByPlayerType(typeof(AttributeName.GoalyAttributes), totalRating, player.MainPosition == Position.Goaly));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.AddPlayerAttributesByPlayerType(typeof(AttributeName.FysicalAttributes), totalRating, IsRandomTrue(Rnd.Next(1,6))));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.AddPlayerAttributesByPlayerType(typeof(AttributeName.MentalAttributes), totalRating, IsRandomTrue(Rnd.Next(1,6))));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.AddPlayerAttributesByPlayerType(typeof(AttributeName.SetPiecesAttributes), totalRating, IsRandomTrue(Rnd.Next(1,6))));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.AddPlayerAttributesByPlayerType(typeof(AttributeName.AttackingAttributes), totalRating, (IsRandomTrue(player.MainPosition) && player.MainPosition != Position.Goaly)));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.AddPlayerAttributesByPlayerType(typeof(AttributeName.DefensiveAttributes), totalRating, player.MainPosition == Position.Defence));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.AddPlayerAttributesByPlayerType(typeof(AttributeName.MidfieldAttribues), totalRating, player.MainPosition == Position.Midfield));
            player.PlayerAttributes.AddRange(PlayerAttributeGeneratorEngine.AddPlayerAttributesByPlayerType(typeof(AttributeName.ForwardAttributes), totalRating, player.MainPosition == Position.Forward));
        }

        private static bool IsRandomTrue(int chanceImprovement)
        {
            var rnd = Rnd.Next(1, 10);
            switch (chanceImprovement)
            {
                case Position.Goaly:
                    return rnd > 8;
                case Position.Defence:
                    return rnd > 7;
                case Position.Midfield:
                    return rnd > 5;
                default:
                    return rnd > 3;
            }
        }
    }
}
