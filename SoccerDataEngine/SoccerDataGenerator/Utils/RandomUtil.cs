﻿using System;
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
