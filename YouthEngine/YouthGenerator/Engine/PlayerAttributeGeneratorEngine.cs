using System;
using System.Collections.Generic;
using YouthGenerator.Data;

namespace YouthGenerator.Engine
{
    public static class PlayerAttributeGeneratorEngine
    {
        private static readonly Random _random = new Random();

        public static Dictionary<string, int> SetGoalyAttributes(int totalRating, bool mainPosition)
        {
            var type = typeof(AttributeName.GoalyAttributes);
            return AddPlayerAttributeByAttributeType(type, totalRating, mainPosition);
        }

        public static Dictionary<string, int> SetDefensiveAttributes(int totalRating, bool mainPosition)
        {
            var type = typeof(AttributeName.DefensiveAttributes);
            return AddPlayerAttributeByAttributeType(type, totalRating, mainPosition);
        }

        public static Dictionary<string, int> SetMidfieldAttributes(int totalRating, bool mainPosition)
        {
            var type = typeof(AttributeName.MidfieldAttribues);
            return AddPlayerAttributeByAttributeType(type, totalRating, mainPosition);
        }

        public static Dictionary<string, int> SetForwardAttributes(int totalRating, bool mainPosition)
        {
            var type = typeof(AttributeName.ForwardAttributes);
            return AddPlayerAttributeByAttributeType(type, totalRating, mainPosition);
        }

        public static Dictionary<string, int> SetFysicalAttributes(int totalRating, bool physicalBeast)
        {
            var type = typeof(AttributeName.FysicalAttributes);
            return AddPlayerAttributeByAttributeType(type, totalRating, physicalBeast);
        }

        public static Dictionary<string, int> SetMentalAttributes(int totalRating, bool isMentalyStrong)
        {
            var type = typeof(AttributeName.MentalAttributes);
            return AddPlayerAttributeByAttributeType(type, totalRating, isMentalyStrong);
        }

        public static Dictionary<string, int> SetAttackingAttributes(int totalRating, bool isAttackingPlayer)
        {
            var type = typeof(AttributeName.AttackingAttributes);
            return AddPlayerAttributeByAttributeType(type, totalRating, isAttackingPlayer);
        }

        public static Dictionary<string, int> SetSetPiecesAttributes(int totalRating, bool isSetPiecePlayer)
        {
            var type = typeof(AttributeName.SetPiecesAttributes);
            return AddPlayerAttributeByAttributeType(type, totalRating, isSetPiecePlayer);
        }

        private static Dictionary<string, int> AddPlayerAttributeByAttributeType(Type type, int totalRating, bool mainPosition)
        {
            var playerAttributes = new Dictionary<string, int>();
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                var ratingOn100 = ((_random.Next(1, totalRating) / 5) *4);
                if (ratingOn100 == 0)
                    ratingOn100++;
                
                if (mainPosition && ratingOn100 < 40 && field.Name != "InjuryProneness")
                    ratingOn100 = _random.Next(40, 55);
                
                playerAttributes.Add(field.Name, ratingOn100);
            }

            return playerAttributes;
        }
    }
}
