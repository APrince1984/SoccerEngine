using System.Collections.Generic;

namespace SoccerDataGenerator.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddRange(this Dictionary<string, int> dictionary, Dictionary<string, int> dictionaryToAdd)
        {
            foreach (var element in dictionaryToAdd)
                dictionary.Add(element.Key, element.Value);
        }
    }
}
