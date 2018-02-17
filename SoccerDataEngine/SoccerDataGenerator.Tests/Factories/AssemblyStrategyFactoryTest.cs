using System;
using System.Collections.Generic;
using NUnit.Framework;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Factories;

namespace SoccerDataGenerator.Tests.Factories
{
    [TestFixture]
    public class AssemblyStrategyFactoryTest
    {
        [Test]
        public void GenerateAssembly_PersonTypePlayer_ReturnsListOfPlayers()
        {
            var players = AssemblyStrategyFactory<Player>.GenerateAssembly(ePerson.Player, 1);
            Assert.IsNotEmpty(players);
            Assert.IsTrue(typeof(List<Player>) == players.GetType());
        }

        [Test]
        public void GenerateAssembly_PersonTypeStaff_ReturnsListOfStaff()
        {
            var staff = AssemblyStrategyFactory<Staff>.GenerateAssembly(ePerson.Staff, 1);
            Assert.IsNotEmpty(staff);
            Assert.IsTrue(typeof(List<Staff>) == staff.GetType());
        }

        [Test]
        public void GenerateAssembly_WrongPersonType_ThrowsException()
        {
            Assert.Throws<InvalidCastException>(() => AssemblyStrategyFactory<Staff>.GenerateAssembly(ePerson.Player, 1));
        }

    }
}
