using System.Collections.Generic;
using YouthGenerator.Data;
using YouthGenerator.Engine;

namespace YouthGenerator.Factory
{
    public static class PersonStrategyFactory<TEntity> where TEntity : Person, new()
    {
        private static readonly Dictionary<ePerson, object> _personDictionary = new Dictionary<ePerson, object>();

        static PersonStrategyFactory()
        {
            _personDictionary.Add(ePerson.Player, new PlayerGeneratorStrategy());
            _personDictionary.Add(ePerson.Coach, new PlayerGeneratorStrategy());
        }

        public static TEntity CreatePlayer(ePerson personType, int totalRating, int mainFunction)
        {
           return ((IPersonGeneratorEngineStrategy<TEntity>) _personDictionary[personType]).CreatePerson(totalRating, mainFunction);
        }

        public static void SetPersonalInformation(ePerson personType, TEntity person)
        {
            ((IPersonGeneratorEngineStrategy<TEntity>)_personDictionary[personType]).SetPersonPersonalInformation(person);
        }

        public static void SetPersonAttributes(ePerson personType, TEntity person)
        {
            ((IPersonGeneratorEngineStrategy<TEntity>)_personDictionary[personType]).SetPersonAttributes(person);
        }
    }

  
}
