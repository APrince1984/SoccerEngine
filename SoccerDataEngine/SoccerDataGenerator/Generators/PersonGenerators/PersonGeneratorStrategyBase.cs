using System;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators.PersonGenerators
{
    public abstract class PersonGeneratorStrategyBase<TEntity> : IPersonGeneratorStrategy<TEntity> where TEntity : Person , new()
    {
        public abstract TEntity CreatePerson(int totalRating, int mainFunction);

        public abstract void SetPersonAttributes(TEntity person);

        public void SetPersonalInformation(TEntity person)
        {
            person.FirstName = DataLists.GetFirstName();
            person.LastName = DataLists.GetLastName();
            person.BirthDate = DateTime.Now.Date.AddYears(-(RandomUtil.GetRandomInt(15, 16))).AddDays(RandomUtil.GetRandomInt(-365, 365));
            person.PersonNationality = DataLists.GetCountry();
        }

        protected internal abstract void SetPersonAttributes(int totalRating, TEntity person);
    }
}
