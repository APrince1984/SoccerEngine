using System;
using System.Collections.Generic;
using NUnit.Framework;
using SoccerDataGenerator.Extensions;

namespace SoccerDataGenerator.Tests.Extensions
{
    [TestFixture]
    public class DictionaryExtensionsTest
    {
        [Test]
        public void AddRange_EmptyExistingDictionary_AddsRangeToExistingDictionary()
        {
            var dict1 = new Dictionary<int, string>();
            var dict2 = new Dictionary<int, string> { {1, "tralalala"} };
            dict1.AddRange(dict2);
            Assert.AreEqual(1, dict1.Count);
            Assert.AreEqual(dict1, dict2);
        }

        [Test]
        public void AddRange_ExistingDictionaryWithValues_AddsRangeToExistingDictionary()
        {
            var dict1 = new Dictionary<int, string> { { 0, "tralalala" } };
            var dict2 = new Dictionary<int, string> { { 1, "tralalala" } };
            dict1.AddRange(dict2);
            Assert.AreEqual(2, dict1.Count);
        }

        [Test]
        public void AddRange_ExistingDictionaryWithValues_WillHaveDoubleKeyValues_ThrowsException()
        {
            var dict1 = new Dictionary<int, string> { { 1, "tralalala1" } };
            var dict2 = new Dictionary<int, string> { { 1, "tralalala2" } };
            Assert.Throws<ArgumentException>(() => dict1.AddRange(dict2));
        }
    }
}
