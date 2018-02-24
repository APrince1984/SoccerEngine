using System;
using System.Collections.Generic;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators.AttributeGenerators
{
    public class AttributeGeneratorBase : IAttributeGenerator
    {
        public Dictionary<string, int> AddPersonAttributesByAttributeType(Type type, int totalRating, bool mainFunction)
        {
            var personAttributes = new Dictionary<string, int>();
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                var ratingOn100 = ((RandomUtil.GetRandomInt(1, totalRating) / 5) * 4);
                if (ratingOn100 == 0)
                    ratingOn100++;
                
                if (mainFunction && ratingOn100 < 40 && field.Name != "InjuryProneness")
                    ratingOn100 = RandomUtil.GetRandomInt(40, 55);

                var ratingOn20 = ratingOn100 / 4 != 0 ? ratingOn100 / 4 : 1;
                personAttributes.Add(field.Name, ratingOn20);
            }

            return personAttributes;
        }
    }
}
