using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Generators.AttributeGenerators;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Tests.Generators.AttributeGenerators
{
    [TestFixture]
    public class AttributeGeneratorTest
    {
        [Test]
        // Player Cases
        [TestCase(typeof(PlayerAttributeName.GoalyAttributes))]
        [TestCase(typeof(PlayerAttributeName.DefensiveAttributes))]
        [TestCase(typeof(PlayerAttributeName.MidfieldAttribues))]
        [TestCase(typeof(PlayerAttributeName.ForwardAttributes))]
        [TestCase(typeof(PlayerAttributeName.FysicalAttributes))]
        [TestCase(typeof(PlayerAttributeName.MentalAttributes))]
        [TestCase(typeof(PlayerAttributeName.SetPiecesAttributes))]
        [TestCase(typeof(PlayerAttributeName.AttackingAttributes))]
        // Staff Cases
        [TestCase(typeof(StaffAttributeName.GoalKeepingAttributes))]
        [TestCase(typeof(StaffAttributeName.DefenseCoachingAttributes))]
        [TestCase(typeof(StaffAttributeName.AttackCoachingAttributes))]
        [TestCase(typeof(StaffAttributeName.MotivationAttributes))]
        [TestCase(typeof(StaffAttributeName.ScoutingAttributes))]
        [TestCase(typeof(StaffAttributeName.GeneralCoachingAttributes))]

        public void AddPersonAttributesByAttributeType_ReturnsPersonAttributesForGivenType(Type attributeType)
        {
            IAttributeGenerator generator = new AttributeGeneratorBase(); 
            var attributes = generator.AddPersonAttributesByAttributeType(attributeType, RandomUtil.GetRandomInt(1,5), true);
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
