using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Generators.AssemblyGenerators;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Tests.Generators.AssemblyGenerators
{
    [TestFixture]
    public class StaffAssemblyGeneratorStrategyTest
    {
        [Test]
        public void CreateAllStaffInAssembly_ReturnsListOfStaff()
        {
            var assembly = new Dictionary<int, int>
            {
                {SpecificStaffFunction.ManagerFunctions.HeadManager,1},
                {SpecificStaffFunction.ManagerFunctions.AssistentManager,1},
                {SpecificStaffFunction.ManagerFunctions.YouthManager,1},
                {SpecificStaffFunction.CoachFunctions.GoalKeepingCoach,1},
                {SpecificStaffFunction.CoachFunctions.DefenceCoach,2},
                {SpecificStaffFunction.CoachFunctions.AttackingCoach,1},
                {SpecificStaffFunction.CoachFunctions.TechnicalCoach,2},
                {SpecificStaffFunction.CoachFunctions.MentalCoach,1},
                {SpecificStaffFunction.CoachFunctions.PhysicalCoach,2},
                {SpecificStaffFunction.ScoutFunctions.FirstTeamScout,2},
                {SpecificStaffFunction.ScoutFunctions.YouthScout,1},
            };
            var staff = AssemblyGeneratorBase<Staff>.CreateAllPersonsInAssembly(assembly, RandomUtil.GetRandomInt(5, 125), ePerson.Staff);
            Assert.IsNotEmpty(staff);
            Assert.AreEqual(15, staff.Count);
            foreach (var element in assembly)
                Assert.AreEqual(element.Value, staff.Count(p => p.MainFunction == element.Key));
        }

        [Test]
        public void CompleteAssembly_StaffIsAdded()
        {
            var assembly = new Dictionary<int, int>
            {
                {SpecificStaffFunction.ManagerFunctions.HeadManager,1},
                {SpecificStaffFunction.ManagerFunctions.AssistentManager,1},
                {SpecificStaffFunction.ManagerFunctions.YouthManager,0},
                {SpecificStaffFunction.CoachFunctions.GoalKeepingCoach,0},
                {SpecificStaffFunction.CoachFunctions.DefenceCoach,0},
                {SpecificStaffFunction.CoachFunctions.AttackingCoach,0},
                {SpecificStaffFunction.CoachFunctions.TechnicalCoach,0},
                {SpecificStaffFunction.CoachFunctions.MentalCoach,0},
                {SpecificStaffFunction.CoachFunctions.PhysicalCoach,0},
                {SpecificStaffFunction.ScoutFunctions.FirstTeamScout,1},
                {SpecificStaffFunction.ScoutFunctions.YouthScout,0}
            };
            var squadGenerator = new StaffAssemblyGeneratorStrategy();
            squadGenerator.CompleteAssembly(assembly);
            var numberOfPlayers = CountNumberOfStaffInSquadAssembly(assembly);

            Assert.AreEqual(AssemblyGeneratorBase<Staff>.NumberOfPersonsInAssembly, numberOfPlayers);
        }

        private static int CountNumberOfStaffInSquadAssembly(Dictionary<int, int> assembly)
        {
            var numberOfStaff = 0;
            foreach (var element in assembly)
                numberOfStaff += element.Value;
            return numberOfStaff;
        }

        [Test]
        public void CompleteAssembly_AssemblyHasEnoughStaff_NoStaffAdded()
        {
            var assembly = new Dictionary<int, int>
            {
                {SpecificStaffFunction.ManagerFunctions.HeadManager,1},
                {SpecificStaffFunction.ManagerFunctions.AssistentManager,1},
                {SpecificStaffFunction.ManagerFunctions.YouthManager,1},
                {SpecificStaffFunction.CoachFunctions.GoalKeepingCoach,1},
                {SpecificStaffFunction.CoachFunctions.DefenceCoach,1},
                {SpecificStaffFunction.CoachFunctions.AttackingCoach,1},
                {SpecificStaffFunction.CoachFunctions.TechnicalCoach,1},
                {SpecificStaffFunction.CoachFunctions.MentalCoach,0},
                {SpecificStaffFunction.CoachFunctions.PhysicalCoach,0},
                {SpecificStaffFunction.ScoutFunctions.FirstTeamScout,0},
                {SpecificStaffFunction.ScoutFunctions.YouthScout,0}
            };
            var squadGenerator = new StaffAssemblyGeneratorStrategy();
            squadGenerator.CompleteAssembly(assembly);
            var numberOfPlayers = CountNumberOfStaffInSquadAssembly(assembly);

            Assert.AreEqual(7, numberOfPlayers);
        }

        [Test]
        public void CountNumberOfStaff_ReturnsNumberOfStaffInSquadAssembly()
        {
            var assembly = new Dictionary<int, int>
            {
                {SpecificStaffFunction.ManagerFunctions.HeadManager,1},
                {SpecificStaffFunction.ManagerFunctions.AssistentManager,1},
                {SpecificStaffFunction.ManagerFunctions.YouthManager,1},
                {SpecificStaffFunction.CoachFunctions.GoalKeepingCoach,1},
                {SpecificStaffFunction.CoachFunctions.DefenceCoach,1},
                {SpecificStaffFunction.CoachFunctions.AttackingCoach,1},
                {SpecificStaffFunction.CoachFunctions.TechnicalCoach,1},
                {SpecificStaffFunction.CoachFunctions.MentalCoach,1},
                {SpecificStaffFunction.CoachFunctions.PhysicalCoach,1},
                {SpecificStaffFunction.ScoutFunctions.FirstTeamScout,1},
                {SpecificStaffFunction.ScoutFunctions.YouthScout,1}
            };
            Assert.AreEqual(11, AssemblyGeneratorBase<Player>.CountNumberOfPersonsInAssembly(assembly));
        }

        [Test]
        public void BuildStaffAssembly_ReturnsStaffAssembly()
        {
            var generator = new StaffAssemblyGeneratorStrategy();
            var assembly = generator.BuildAssembly();
            Assert.IsNotEmpty(assembly);
            Assert.AreEqual(1, assembly[SpecificStaffFunction.ManagerFunctions.HeadManager]);
            Assert.AreEqual(1, assembly[SpecificStaffFunction.ManagerFunctions.AssistentManager]);
            Assert.AreEqual(1, assembly[SpecificStaffFunction.CoachFunctions.GoalKeepingCoach]);

            Assert.LessOrEqual(assembly[SpecificStaffFunction.ManagerFunctions.YouthManager], 1);
            Assert.LessOrEqual(assembly[SpecificStaffFunction.CoachFunctions.AttackingCoach], 1);
            Assert.LessOrEqual(assembly[SpecificStaffFunction.CoachFunctions.DefenceCoach], 1);
            Assert.LessOrEqual(assembly[SpecificStaffFunction.CoachFunctions.TechnicalCoach], 1);
            Assert.LessOrEqual(assembly[SpecificStaffFunction.CoachFunctions.MentalCoach], 1);
            Assert.LessOrEqual(assembly[SpecificStaffFunction.CoachFunctions.PhysicalCoach], 1);
            Assert.LessOrEqual(assembly[SpecificStaffFunction.ScoutFunctions.FirstTeamScout], 2);
            Assert.LessOrEqual(assembly[SpecificStaffFunction.ScoutFunctions.YouthScout], 2);

            Assert.GreaterOrEqual(assembly[SpecificStaffFunction.ManagerFunctions.YouthManager], 0);
            Assert.GreaterOrEqual(assembly[SpecificStaffFunction.CoachFunctions.AttackingCoach], 0);
            Assert.GreaterOrEqual(assembly[SpecificStaffFunction.CoachFunctions.DefenceCoach], 0);
            Assert.GreaterOrEqual(assembly[SpecificStaffFunction.CoachFunctions.TechnicalCoach], 0);
            Assert.GreaterOrEqual(assembly[SpecificStaffFunction.CoachFunctions.MentalCoach], 0);
            Assert.GreaterOrEqual(assembly[SpecificStaffFunction.CoachFunctions.PhysicalCoach], 0);
            Assert.GreaterOrEqual(assembly[SpecificStaffFunction.ScoutFunctions.FirstTeamScout], 1);
            Assert.GreaterOrEqual(assembly[SpecificStaffFunction.ScoutFunctions.YouthScout], 0);
        }

        [Test]
        public void GenerateStaff_ReturnsListOfStaffContainingAtLeast6StaffMembers()
        {
            var generator = new StaffAssemblyGeneratorStrategy();
            var staff = generator.GenerateAssembly(ePerson.Staff, RandomUtil.GetRandomInt(1, 5), RandomUtil.GetRandomInt(1, 5), RandomUtil.GetRandomInt(1, 5));
            Assert.IsNotEmpty(staff);
            Assert.GreaterOrEqual(staff.Count, 6);
            Assert.AreEqual(1, staff.Count(s => s.MainFunction == SpecificStaffFunction.ManagerFunctions.HeadManager));
            Assert.AreEqual(1, staff.Count(s => s.MainFunction == SpecificStaffFunction.ManagerFunctions.AssistentManager));
            Assert.AreEqual(1, staff.Count(s => s.MainFunction == SpecificStaffFunction.CoachFunctions.GoalKeepingCoach));
        }

        [Test]
        public void AddPersonToAssembly_NoAllAssemblyElementsHaveValue_PersonIsAddedToEmptyAssembly()
        {
            var assembly = new Dictionary<int, int>
            {
                {SpecificStaffFunction.ManagerFunctions.HeadManager, 1},
                {SpecificStaffFunction.ManagerFunctions.AssistentManager, 1},
                {SpecificStaffFunction.ManagerFunctions.YouthManager, 0}
            };
            var generator = new StaffAssemblyGeneratorStrategy();
            generator.AddPersonToAssembly(assembly);
            Assert.AreEqual(1, assembly[SpecificStaffFunction.ManagerFunctions.HeadManager]);
            Assert.AreEqual(1, assembly[SpecificStaffFunction.ManagerFunctions.AssistentManager]);
            Assert.AreEqual(1, assembly[SpecificStaffFunction.ManagerFunctions.YouthManager]);
        }

        [Test]
        public void AddPersonToAssembly_AllAssemblyElementsHaveValue_PersonIsAdded()
        {
            var assembly = new Dictionary<int, int>
            {
                {SpecificStaffFunction.ManagerFunctions.HeadManager, 1},
                {SpecificStaffFunction.ManagerFunctions.AssistentManager, 1},
                {SpecificStaffFunction.ManagerFunctions.YouthManager, 1}
            };
            var generator = new StaffAssemblyGeneratorStrategy();
            generator.AddPersonToAssembly(assembly);
            Assert.AreEqual(4, StaffAssemblyGeneratorStrategy.CountNumberOfPersonsInAssembly(assembly));
        }
    }
}
