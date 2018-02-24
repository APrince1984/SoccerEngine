using System;
using System.Linq;

namespace SoccerDataGenerator.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSpaces(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
