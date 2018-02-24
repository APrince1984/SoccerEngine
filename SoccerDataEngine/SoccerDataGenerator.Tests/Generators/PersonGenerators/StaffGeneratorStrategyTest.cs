using System;
using System.Linq;
using NUnit.Framework;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Factories;
using SoccerDataGenerator.Generators.PersonGenerators;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Tests.Generators.PersonGenerators
{
    [TestFixture]
    public class StaffGeneratorStrategyTest
    {
        [Test]
        [TestCase(SpecificStaffFunction.CoachFunctions.GoalKeepingCoach)]
        [TestCase(SpecificStaffFunction.CoachFunctions.AttackingCoach)]
        [TestCase(SpecificStaffFunction.CoachFunctions.DefenceCoach)]
        [TestCase(SpecificStaffFunction.CoachFunctions.MentalCoach)]
        [TestCase(SpecificStaffFunction.CoachFunctions.PhysicalCoach)]
        [TestCase(SpecificStaffFunction.CoachFunctions.TechnicalCoach)]
        [TestCase(SpecificStaffFunction.ManagerFunctions.HeadManager)]
        [TestCase(SpecificStaffFunction.ManagerFunctions.AssistentManager)]
        [TestCase(SpecificStaffFunction.ManagerFunctions.YouthManager)]
        [TestCase(SpecificStaffFunction.ScoutFunctions.YouthScout)]
        [TestCase(SpecificStaffFunction.ScoutFunctions.FirstTeamScout)]
        public void CreateStaff_ReturnsStaffWithPositionsAndAttributes(int mainFunction)
        {
            var staff = PersonStrategyFactory<Staff>.CreatePerson(ePerson.Staff, RandomUtil.GetRandomInt(5, 25), mainFunction);
            Assert.IsNotNull(staff);
            Assert.IsNotNull(staff.MainFunction);
            Assert.IsNotEmpty(staff.PersonAttributes);
            Assert.AreEqual(12, staff.PersonAttributes.Count);
        }

        [Test]
        public void SetStaffPersonalSettings_ReturnsStaffWithPersonalSettings()
        {
            var staff = new Staff();
            PersonStrategyFactory<Staff>.SetPersonalInformation(ePerson.Staff, staff);
            Assert.IsNotNull(staff.FirstName);
            Assert.IsNotNull(staff.LastName);
            Assert.IsNotNull(staff.BirthDate);
            Assert.IsTrue(staff.BirthDate < DateTime.Now.Date);
        }

        [Test]
        [TestCase(SpecificStaffFunction.CoachFunctions.GoalKeepingCoach)]
        [TestCase(SpecificStaffFunction.CoachFunctions.AttackingCoach)]
        [TestCase(SpecificStaffFunction.CoachFunctions.DefenceCoach)]
        [TestCase(SpecificStaffFunction.CoachFunctions.MentalCoach)]
        [TestCase(SpecificStaffFunction.CoachFunctions.PhysicalCoach)]
        [TestCase(SpecificStaffFunction.CoachFunctions.TechnicalCoach)]
        [TestCase(SpecificStaffFunction.ManagerFunctions.HeadManager)]
        [TestCase(SpecificStaffFunction.ManagerFunctions.AssistentManager)]
        [TestCase(SpecificStaffFunction.ManagerFunctions.YouthManager)]
        [TestCase(SpecificStaffFunction.ScoutFunctions.YouthScout)]
        [TestCase(SpecificStaffFunction.ScoutFunctions.FirstTeamScout)]
        public void SetStaffAttributes_SetsAllStaffAttributes(int mainFunction)
        {
            var staff = new Staff { MainFunction = mainFunction };
            var generatorStrategy = new StaffGeneratorStrategy();
            generatorStrategy.SetPersonAttributes(RandomUtil.GetRandomInt(5, 125), staff);
            Assert.IsNotNull(staff.PersonAttributes);
            Assert.AreEqual(12, staff.PersonAttributes.Count);
            var fields = typeof(StaffAttributeName.GoalKeepingAttributes).GetFields();
            foreach (var field in fields)
                Assert.IsTrue(staff.PersonAttributes.Keys.Contains(field.Name));
        }
    }
}

