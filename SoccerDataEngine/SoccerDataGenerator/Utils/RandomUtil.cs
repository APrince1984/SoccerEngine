using System;
using System.Collections.Generic;
using System.Linq;
using SoccerDataGenerator.Data;

namespace SoccerDataGenerator.Utils
{
    public static class RandomUtil
    {
        private static readonly Random Rnd = new Random();


        public static int GetRandomInt(int minValue, int maxValue)
        {
            return Rnd.Next(minValue, maxValue);
        }

        public static T GetRandomObject<T>(List<T> obj) where T : class 
        {
            var index = Rnd.Next(obj.Count);
            return obj[index];
        }

        public static Dictionary<TKey, TValue> GetRandomDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            var index = Rnd.Next(dictionary.Count);
            return new Dictionary<TKey, TValue> { {dictionary.Keys.ElementAt(index), dictionary.Values.ElementAt(index)}};
        }

        public static bool GetRandomBoolWithPossiblityToImproveChances(int chanceImprovement = 0)
        {
            var rnd = GetRandomInt(1, 10);
            switch (chanceImprovement)
            {
                case 1:
                    return rnd > 8;
                case 2:
                    return rnd > 7;
                case 3:
                    return rnd > 5;
                default:
                    return rnd > 3;
            }
        }
    }
}
