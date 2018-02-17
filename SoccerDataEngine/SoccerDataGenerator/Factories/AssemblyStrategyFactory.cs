using System.Collections.Generic;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Generators;

namespace SoccerDataGenerator.Factories
{
    public static class AssemblyStrategyFactory<TEntity> where TEntity : Person, new ()
    {
        private static readonly Dictionary<ePerson, object> AssemblyDictionary = new Dictionary<ePerson, object>();

        static AssemblyStrategyFactory()
        {
            AssemblyDictionary.Add(ePerson.Player, new SquadGenerator());
            AssemblyDictionary.Add(ePerson.Coach, new StaffGenerator());
        }

        public static List<TEntity> GenerateAssembly(ePerson personType, int countryRating,
            int? competitionRation = null, int? teamRating = null)
        {
            return ((IAssemblyGenerator<TEntity>) AssemblyDictionary[personType]).GenerateAssembly(personType, countryRating, competitionRation, teamRating);
        }
    }
}
