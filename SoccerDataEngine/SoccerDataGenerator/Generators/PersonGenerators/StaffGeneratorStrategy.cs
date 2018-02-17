using System;
using SoccerDataGenerator.Data;

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

        protected internal override void SetPersonAttributes(int totalRating, Staff person)
        {
           // throw new NotImplementedException();
        }
    }
}
