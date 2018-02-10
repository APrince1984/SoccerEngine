using System;
using System.Collections.Generic;
using YouthGenerator.Data;

namespace YouthGenerator.Engine
{
    public static class PlayerAttributeGeneratorEngine
    {
        private static readonly Random Rnd = new Random();

        public static Dictionary<string, int> AddPlayerAttributesByPlayerType(Type type, int totalRating, bool mainPosition)
        {
            var playerAttributes = new Dictionary<string, int>();
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                var ratingOn100 = ((Rnd.Next(1, totalRating) / 5) *4);
                if (ratingOn100 == 0)
                    ratingOn100++;
                
                if (mainPosition && ratingOn100 < 40 && field.Name != "InjuryProneness")
                    ratingOn100 = Rnd.Next(40, 55);
                
                playerAttributes.Add(field.Name, ratingOn100);
            }

            return playerAttributes;
        }
    }
}
