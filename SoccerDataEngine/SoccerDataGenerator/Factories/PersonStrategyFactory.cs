using System.Collections.Generic;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Generators;

namespace SoccerDataGenerator.Factories
{
    public static class PersonStrategyFactory<TEntity> where TEntity : Person, new()
    {
        private static readonly Dictionary<ePerson, object> _personDictionary = new Dictionary<ePerson, object>();

        static PersonStrategyFactory()
        {
            _personDictionary.Add(ePerson.Player, new PlayerGeneratorStrategy());
            _personDictionary.Add(ePerson.Coach, new CoachGeneratorStrategy());
        }

        public static TEntity CreatePlayer(ePerson personType, int totalRating, int mainFunction)
        {
           return ((IPersonGeneratorStrategy<TEntity>) _personDictionary[personType]).CreatePerson(totalRating, mainFunction);
        }

        public static void SetPersonalInformation(ePerson personType, TEntity person)
        {
            ((IPersonGeneratorStrategy<TEntity>)_personDictionary[personType]).SetPersonalInformation(person);
        }

        public static void SetPersonAttributes(ePerson personType, TEntity person)
        {
            ((IPersonGeneratorStrategy<TEntity>)_personDictionary[personType]).SetPersonAttributes(person);
        }
    }

  
}
