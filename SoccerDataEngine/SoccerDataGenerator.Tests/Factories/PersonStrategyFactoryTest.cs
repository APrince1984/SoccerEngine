using System;
using NUnit.Framework;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Factories;

namespace SoccerDataGenerator.Tests.Factories
{
    [TestFixture]
    public class PersonStrategyFactoryTest
    {
        [Test]
        public void CreatePerson_TypePlayer_ReturnsPlayer()
        {
            var person = PersonStrategyFactory<Player>.CreatePerson(ePerson.Player, 100, Position.Goaly);
            Assert.IsNotNull(person);
            Assert.IsTrue(typeof(Player) == person.GetType());
        }

        [Test]
        public void CreatePerson_TypeStaff_ReturnsStaffMember()
        {
            var person = PersonStrategyFactory<Staff>.CreatePerson(ePerson.Staff, 100, SpecificStaffFunction.ManagerFunctions.HeadManager);
            Assert.IsNotNull(person);
            Assert.IsTrue(typeof(Staff) == person.GetType());
        }

        [Test]
        public void CreatePerson_WrongPersonType_ThrowsException()
        {
            Assert.Throws<InvalidCastException>(() => PersonStrategyFactory<Staff>.CreatePerson(ePerson.Player, 100, Position.Goaly));
        }
    }
}
