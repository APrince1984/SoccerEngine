using System.Collections.Generic;
using System.Linq;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators.AssemblyGenerators
{
    public class StaffAssemblyGeneratorStrategy : AssemblyGeneratorBase<Staff>
    {
        public StaffAssemblyGeneratorStrategy()
        {
            NumberOfPersonsInAssembly = 6;
        }

        protected internal override Dictionary<int, int> BuildAssembly()
        {
            return new Dictionary<int, int>
            {
                { SpecificStaffFunction.ManagerFunctions.HeadManager, 1 },
                { SpecificStaffFunction.ManagerFunctions.AssistentManager, 1 },
                { SpecificStaffFunction.ManagerFunctions.YouthManager, RandomUtil.GetRandomInt(0,1) },

                { SpecificStaffFunction.CoachFunctions.AttackingCoach, RandomUtil.GetRandomInt(0,1)},
                { SpecificStaffFunction.CoachFunctions.DefenceCoach, RandomUtil.GetRandomInt(0,1)},
                { SpecificStaffFunction.CoachFunctions.GoalKeepingCoach, 1},
                { SpecificStaffFunction.CoachFunctions.MentalCoach, RandomUtil.GetRandomInt(0,1)},
                { SpecificStaffFunction.CoachFunctions.PhysicalCoach, RandomUtil.GetRandomInt(0,1)},
                { SpecificStaffFunction.CoachFunctions.TechnicalCoach , RandomUtil.GetRandomInt(0,1)},

                { SpecificStaffFunction.ScoutFunctions.FirstTeamScout, RandomUtil.GetRandomInt(1,2) },
                { SpecificStaffFunction.ScoutFunctions.YouthScout, RandomUtil.GetRandomInt(0,2) },
            };
        }

        protected internal override void AddPersonToAssembly(Dictionary<int, int> assembly)
        {
            var allFunctionsWithoutPersons = assembly.Where(a => a.Value == 0).ToDictionary(a => a.Key);
            if (allFunctionsWithoutPersons.Any())
                assembly[allFunctionsWithoutPersons.ElementAt(RandomUtil.GetRandomInt(0, allFunctionsWithoutPersons.Count() - 1)).Key] += 1;
            else
                assembly[assembly.Keys.ElementAt(RandomUtil.GetRandomInt(0, (assembly.Count - 1)))] += 1;
        }
    }
}
