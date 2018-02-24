using System;
using System.Collections.Generic;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Extensions;
using SoccerDataGenerator.Generators.AttributeGenerators;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators.PersonGenerators
{
    public class StaffGeneratorStrategy : PersonGeneratorStrategyBase<Staff>
    {
        public override Staff CreatePerson(int totalRating, int mainFunction)
        {
            var coach = new Staff();
            coach.MainFunction = mainFunction;
            SetPersonalInformation(coach);
            SetPersonAttributes(coach);
            SetPersonAttributes(totalRating, coach);
            return coach;
        }

        public override void SetPersonAttributes(Staff person)
        {
        }

        protected internal override void SetPersonAttributes(int totalRating, Staff staff)
        {
            staff.PersonAttributes = new Dictionary<string, int>();
            var generator = new AttributeGeneratorBase();
            staff.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(StaffAttributeName.AttackCoachingAttributes), totalRating, staff.MainFunction == SpecificStaffFunction.CoachFunctions.AttackingCoach || staff.MainFunction == SpecificStaffFunction.CoachFunctions.TechnicalCoach));
            staff.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(StaffAttributeName.DefenseCoachingAttributes), totalRating, staff.MainFunction == SpecificStaffFunction.CoachFunctions.DefenceCoach));
            staff.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(StaffAttributeName.GoalKeepingAttributes), totalRating, staff.MainFunction == SpecificStaffFunction.CoachFunctions.GoalKeepingCoach));
            staff.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(StaffAttributeName.MotivationAttributes), totalRating, staff.MainFunction == SpecificStaffFunction.ManagerFunctions.HeadManager || staff.MainFunction == SpecificStaffFunction.ManagerFunctions.AssistentManager || staff.MainFunction == SpecificStaffFunction.ManagerFunctions.YouthManager));
            staff.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(StaffAttributeName.ScoutingAttributes), totalRating, staff.MainFunction == SpecificStaffFunction.ScoutFunctions.YouthScout || staff.MainFunction == SpecificStaffFunction.ScoutFunctions.FirstTeamScout));
            staff.PersonAttributes.AddRange(generator.AddPersonAttributesByAttributeType(typeof(StaffAttributeName.GeneralCoachingAttributes), totalRating, staff.MainFunction == SpecificStaffFunction.CoachFunctions.MentalCoach || staff.MainFunction == SpecificStaffFunction.CoachFunctions.PhysicalCoach));
        }
    }
}
