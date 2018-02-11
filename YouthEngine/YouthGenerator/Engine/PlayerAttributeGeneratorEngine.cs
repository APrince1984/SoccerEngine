using System;
using System.Collections.Generic;

namespace YouthGenerator.Engine
{
    public static class PlayerAttributeGeneratorEngine
    {
        public static Dictionary<string, int> AddPlayerAttributesByPlayerType(Type type, int totalRating, bool mainPosition)
        {
            var playerAttributes = new Dictionary<string, int>();
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                var ratingOn100 = ((RandomEngine.GetRandomInt(1, totalRating) / 5) *4);
                if (ratingOn100 == 0)
                    ratingOn100++;
                
                if (mainPosition && ratingOn100 < 40 && field.Name != "InjuryProneness")
                    ratingOn100 = RandomEngine.GetRandomInt(40, 55);
                
                playerAttributes.Add(field.Name, ratingOn100);
            }

            return playerAttributes;
        }
    }
}
