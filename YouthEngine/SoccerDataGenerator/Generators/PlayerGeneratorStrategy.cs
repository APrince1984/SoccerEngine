using System;
using System.Collections.Generic;
using System.Reflection;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Engine;
using SoccerDataGenerator.Extensions;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators
{
    
    public class PlayerGeneratorStrategy : IPersonGeneratorEngineStrategy<Player>
    {
        public Player CreatePerson(int totalRating, int mainPosition)
        {
            var player = new Player();
            player.MainPosition = mainPosition;
            SetPersonPersonalInformation(player);
            SetPersonAttributes(player);
            SetPlayerAttributes(totalRating, player);
            return player;
        }

        public void SetPersonPersonalInformation(Player player)
        {
            player.FirstName = DataLists.GetFirstName();
            player.LastName = DataLists.GetLastName();
            player.BirthDate = DateTime.Now.Date.AddYears(-(RandomUtil.GetRandomInt(15, 16))).AddDays(RandomUtil.GetRandomInt(-365, 365));
            player.PersonNationality = DataLists.GetCountry();
        }

        public void SetPersonAttributes(Player player)
        {
            if (player.MainPosition == Position.Goaly)
            {
                player.Positions = new List<int> {PlayerPosition.Goaly};
                return;
            }
            
            player.Positions = new List<int>();
            var nbrOfPositions = player.MainPosition == Position.Forward ? RandomUtil.GetRandomInt(1, 2) : RandomUtil.GetRandomInt(1, 3);
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
            var index = RandomUtil.GetRandomInt(0, playerPositions.Length);
            return (int) playerPositions[index].GetValue(playerPositions[index].Name);
        }

        internal static void SetPlayerAttributes(int totalRating, Player player)
        {
            player.PlayerAttributes = new Dictionary<string, int>();
            player.PlayerAttributes.AddRange(PlayerAttributeGenerator.AddPlayerAttributesByPlayerType(typeof(AttributeName.GoalyAttributes), totalRating, player.MainPosition == Position.Goaly));
            player.PlayerAttributes.AddRange(PlayerAttributeGenerator.AddPlayerAttributesByPlayerType(typeof(AttributeName.FysicalAttributes), totalRating, RandomUtil.GetRandomBoolWithPossiblityToImproveChances(RandomUtil.GetRandomInt(1, 6))));
            player.PlayerAttributes.AddRange(PlayerAttributeGenerator.AddPlayerAttributesByPlayerType(typeof(AttributeName.MentalAttributes), totalRating, RandomUtil.GetRandomBoolWithPossiblityToImproveChances(RandomUtil.GetRandomInt(1,6))));
            player.PlayerAttributes.AddRange(PlayerAttributeGenerator.AddPlayerAttributesByPlayerType(typeof(AttributeName.SetPiecesAttributes), totalRating, RandomUtil.GetRandomBoolWithPossiblityToImproveChances(RandomUtil.GetRandomInt(1,6))));
            player.PlayerAttributes.AddRange(PlayerAttributeGenerator.AddPlayerAttributesByPlayerType(typeof(AttributeName.AttackingAttributes), totalRating, (RandomUtil.GetRandomBoolWithPossiblityToImproveChances(player.MainPosition) && player.MainPosition != Position.Goaly)));
            player.PlayerAttributes.AddRange(PlayerAttributeGenerator.AddPlayerAttributesByPlayerType(typeof(AttributeName.DefensiveAttributes), totalRating, player.MainPosition == Position.Defence));
            player.PlayerAttributes.AddRange(PlayerAttributeGenerator.AddPlayerAttributesByPlayerType(typeof(AttributeName.MidfieldAttribues), totalRating, player.MainPosition == Position.Midfield));
            player.PlayerAttributes.AddRange(PlayerAttributeGenerator.AddPlayerAttributesByPlayerType(typeof(AttributeName.ForwardAttributes), totalRating, player.MainPosition == Position.Forward));
        }
    }
}
