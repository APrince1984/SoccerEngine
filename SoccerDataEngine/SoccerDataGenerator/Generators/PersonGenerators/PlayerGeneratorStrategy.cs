using System;
using System.Collections.Generic;
using System.Reflection;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Extensions;
using SoccerDataGenerator.Generators.AttributeGenerators;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators.PersonGenerators
{
    
    public class PlayerGeneratorStrategy : PersonGeneratorStrategyBase<Player>
    {
        public override Player CreatePerson(int totalRating, int mainPosition)
        {
            var player = new Player();
            player.MainFunction = mainPosition;
            SetPersonalInformation(player);
            SetPersonAttributes(player);
            SetPersonAttributes(totalRating, player);
            return player;
        }

        public override void SetPersonAttributes(Player player)
        {
            if (player.MainFunction == Position.Goaly)
            {
                player.Positions = new List<int> {PlayerPosition.Goaly};
                return;
            }
            
            player.Positions = new List<int>();
            var nbrOfPositions = player.MainFunction == Position.Forward ? RandomUtil.GetRandomInt(1, 2) : RandomUtil.GetRandomInt(1, 3);
            for (var i = 1; i <= nbrOfPositions; i++)
            {
                switch (player.MainFunction)
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

        protected internal override void SetPersonAttributes(int totalRating, Player player)
        {
            player.PersonAttributes = new Dictionary<string, int>();
            var generator = new AttributeGeneratorBase();
            player.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(PlayerAttributeName.GoalyAttributes), totalRating, player.MainFunction == Position.Goaly));
            player.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(PlayerAttributeName.FysicalAttributes), totalRating, RandomUtil.GetRandomBoolWithPossiblityToImproveChances(RandomUtil.GetRandomInt(1, 6))));
            player.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(PlayerAttributeName.MentalAttributes), totalRating, RandomUtil.GetRandomBoolWithPossiblityToImproveChances(RandomUtil.GetRandomInt(1,6))));
            player.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(PlayerAttributeName.SetPiecesAttributes), totalRating, RandomUtil.GetRandomBoolWithPossiblityToImproveChances(RandomUtil.GetRandomInt(1,6))));
            player.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(PlayerAttributeName.AttackingAttributes), totalRating, (RandomUtil.GetRandomBoolWithPossiblityToImproveChances(player.MainFunction) && player.MainFunction != Position.Goaly)));
            player.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(PlayerAttributeName.DefensiveAttributes), totalRating, player.MainFunction == Position.Defence));
            player.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(PlayerAttributeName.MidfieldAttribues), totalRating, player.MainFunction == Position.Midfield));
            player.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(PlayerAttributeName.ForwardAttributes), totalRating, player.MainFunction == Position.Forward));
        }
    }
}
