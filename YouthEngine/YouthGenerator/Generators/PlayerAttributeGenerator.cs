using System;
using System.Collections.Generic;
using YouthGenerator.Utils;

namespace YouthGenerator.Engine
{
    public static class PlayerAttributeGenerator
    {
        public static Dictionary<string, int> AddPlayerAttributesByPlayerType(Type type, int totalRating, bool mainPosition)
        {
            var playerAttributes = new Dictionary<string, int>();
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                var ratingOn100 = ((RandomUtil.GetRandomInt(1, totalRating) / 5) *4);
                if (ratingOn100 == 0)
                    ratingOn100++;
                
                if (mainPosition && ratingOn100 < 40 && field.Name != "InjuryProneness")
                    ratingOn100 = RandomUtil.GetRandomInt(40, 55);

                var ratingOn20 = ratingOn100 / 4 != 0 ? ratingOn100 / 4 : 1; 
                playerAttributes.Add(field.Name, ratingOn20);
            }

            return playerAttributes;
        }
    }
}
