using System;
using System.Collections.Generic;
using SoccerDataGenerator.Data;

namespace SoccerDataGenerator.Generators
{
    public class CoachGeneratorStrategy : PersonGeneratorStrategyBase<Coach>
    {
        public override Coach CreatePerson(int totalRating, int mainFunction)
        {
            var coach = new Coach();
            coach.MainFunction = mainFunction;
            SetPersonalInformation(coach);
            SetPersonAttributes(coach);
            SetPersonAttributes(totalRating, coach);
            return coach;
        }

        public override void SetPersonAttributes(Coach person)
        {
        }

        protected internal override void SetPersonAttributes(int totalRating, Coach person)
        {
            throw new NotImplementedException();
        }
    }
}
