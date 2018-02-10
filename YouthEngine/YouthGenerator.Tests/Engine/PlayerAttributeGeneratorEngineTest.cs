using System;
using System.Linq;
using NUnit.Framework;
using YouthGenerator.Data;
using YouthGenerator.Engine;
using YouthGenerator.Extensions;

namespace YouthGenerator.Tests.Engine
{
    [TestFixture]
    public class PlayerAttributeGeneratorEngineTest
    {
        private static Random _random = new Random();
        [Test]
        public void AddPlayerAttributesByPlayerType_TypeIsGoaly_ReturnsPlayerAttributesForGoaly()
        {
            var totalRating = _random.Next(1, 5);
            var attributes = PlayerAttributeGeneratorEngine.AddPlayerAttributesByPlayerType(typeof(AttributeName.GoalyAttributes), totalRating, true);
            Assert.IsNotEmpty(attributes);
            Assert.AreEqual(3, attributes.Count);
            Assert.IsTrue(attributes.ContainsKey(AttributeName.GoalyAttributes.Reflexes.RemoveWhitespace()));
            Assert.IsTrue(attributes.ContainsKey(AttributeName.GoalyAttributes.Ballhandling.RemoveWhitespace()));
            Assert.IsTrue(attributes.ContainsKey(AttributeName.GoalyAttributes.PenaltyStopping.RemoveWhitespace()));
            Assert.GreaterOrEqual(attributes.FirstOrDefault(a => a.Key == AttributeName.GoalyAttributes.Reflexes.RemoveWhitespace()).Value, 40);
            Assert.GreaterOrEqual(attributes.FirstOrDefault(a => a.Key == AttributeName.GoalyAttributes.Ballhandling.RemoveWhitespace()).Value, 40);
            Assert.GreaterOrEqual(attributes.FirstOrDefault(a => a.Key == AttributeName.GoalyAttributes.PenaltyStopping.RemoveWhitespace()).Value, 40);
        }
    }
}
