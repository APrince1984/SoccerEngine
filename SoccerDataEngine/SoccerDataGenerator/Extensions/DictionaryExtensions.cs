using System.Collections.Generic;

namespace SoccerDataGenerator.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> dictionaryToAdd)
        {
            foreach (var element in dictionaryToAdd)
                dictionary.Add(element.Key, element.Value);
        }
    }
}
