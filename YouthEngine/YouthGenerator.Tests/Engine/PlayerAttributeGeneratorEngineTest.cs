using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using YouthGenerator.Data;
using YouthGenerator.Engine;

namespace YouthGenerator.Tests.Engine
{
    [TestFixture]
    public class PlayerAttributeGeneratorEngineTest
    {
        private static readonly Random _random = new Random();

        [Test]
        [TestCase(typeof(AttributeName.GoalyAttributes))]
        [TestCase(typeof(AttributeName.DefensiveAttributes))]
        [TestCase(typeof(AttributeName.MidfieldAttribues))]
        [TestCase(typeof(AttributeName.ForwardAttributes))]
        [TestCase(typeof(AttributeName.FysicalAttributes))]
        [TestCase(typeof(AttributeName.MentalAttributes))]
        [TestCase(typeof(AttributeName.SetPiecesAttributes))]
        [TestCase(typeof(AttributeName.AttackingAttributes))]
        public void AddPlayerAttributesByPlayerType_ReturnsPlayerAttributesForGivenType(Type attributeType)
        {
            var attributes = PlayerAttributeGeneratorEngine.AddPlayerAttributesByPlayerType(attributeType, _random.Next(1, 5), true);
            AssertAttributesByType(attributes, attributeType);
        }


        private void AssertAttributesByType(Dictionary<string, int> attributes, Type type)
        {
            Assert.IsNotEmpty(attributes);
            var fields = type.GetFields();
            Assert.AreEqual(fields.Count(), attributes.Count);
            foreach (var field in fields)
            {
                Assert.IsTrue(attributes.ContainsKey(field.Name));
                if (field.Name != "InjuryProneness")
                    Assert.GreaterOrEqual(attributes.FirstOrDefault(attr => attr.Key == field.Name).Value, 8);
            }
        }
    }
}
