using System;

namespace YouthGenerator.Engine
{
    public static class RandomEngine
    {
        private static readonly Random Rnd = new Random();

        public static int GetRandomInt(int minValue, int maxValue)
        {
            return Rnd.Next(minValue, maxValue);
        }
    }
}
