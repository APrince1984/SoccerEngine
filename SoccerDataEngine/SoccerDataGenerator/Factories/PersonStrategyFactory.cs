using System.Collections.Generic;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Generators;
using SoccerDataGenerator.Generators.PersonGenerators;

namespace SoccerDataGenerator.Factories
{
    public static class PersonStrategyFactory<TEntity> where TEntity : Person, new()
    {
        private static readonly Dictionary<ePerson, object> PersonDictionary = new Dictionary<ePerson, object>();

        static PersonStrategyFactory()
        {
            PersonDictionary.Add(ePerson.Player, new PlayerGeneratorStrategy());
            PersonDictionary.Add(ePerson.Staff, new StaffGeneratorStrategy());
        }

        public static TEntity CreatePlayer(ePerson personType, int totalRating, int mainFunction)
        {
           return ((IPersonGeneratorStrategy<TEntity>) PersonDictionary[personType]).CreatePerson(totalRating, mainFunction);
        }

        public static void SetPersonalInformation(ePerson personType, TEntity person)
        {
            ((IPersonGeneratorStrategy<TEntity>)PersonDictionary[personType]).SetPersonalInformation(person);
        }

        public static void SetPersonAttributes(ePerson personType, TEntity person)
        {
            ((IPersonGeneratorStrategy<TEntity>)PersonDictionary[personType]).SetPersonAttributes(person);
        }
    }

  
}
