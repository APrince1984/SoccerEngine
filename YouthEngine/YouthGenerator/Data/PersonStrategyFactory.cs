using System;
using System.Collections.Generic;
using YouthGenerator.Engine;

namespace YouthGenerator.Data
{
    public static class PersonStrategyFactory<TEntity> where TEntity : Person, new()
    {
        private static readonly Dictionary<ePerson, object> _personDictionary = new Dictionary<ePerson, object>();

        static PersonStrategyFactory()
        {
            _personDictionary.Add(ePerson.Player, new YouthGeneratorEngineStrategy());
            _personDictionary.Add(ePerson.Coach, new YouthGeneratorEngineStrategy());
        }

        public static TEntity CreatePlayer(ePerson personType, int totalRating, int mainFunction)
        {
           return ((IPersonGeneratorEngineStrategy<TEntity>) _personDictionary[personType]).CreatePerson(totalRating, mainFunction);
        }
    }

  
}
