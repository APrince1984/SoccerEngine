﻿using System.Collections.Generic;
using System.Linq;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Factories;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators.AssemblyGenerators
{
    public abstract class AssemblyGeneratorBase<TEntity> : IAssemblyGenerator<TEntity> where TEntity : Person, new()
    {
        protected internal static int NumberOfPersonsInAssembly { get; set; }

        public List<TEntity> GenerateAssembly(ePerson personType, int countryRating, int? competitionRation = null, int? teamRating = null)
        {
            var totalRating = teamRating != null && competitionRation != null
                ? countryRating * (int) competitionRation * (int) teamRating
                : countryRating * RandomUtil.GetRandomInt(2, 5) * RandomUtil.GetRandomInt(2, 5);
            var assembly = BuildAssembly();
            CompleteAssembly(assembly);
            return CreateAllPersonsInAssembly(assembly, totalRating, personType);
        }

        protected internal abstract Dictionary<int, int> BuildAssembly();

        protected internal void CompleteAssembly(Dictionary<int, int> assembly)
        {
            var personsInAssembly = CountNumberOfPersonsInAssembly(assembly);
            while (personsInAssembly < NumberOfPersonsInAssembly)
            {
                AddPersonToAssembly(assembly);
                personsInAssembly++;
            }
        }

        protected internal static int CountNumberOfPersonsInAssembly(Dictionary<int, int> assembly)
        {
            var totalNumberOfPersons = 0;
            foreach (var person in assembly)
                totalNumberOfPersons += person.Value;
            return totalNumberOfPersons;
        }

        protected internal static List<TEntity> CreateAllPersonsInAssembly(Dictionary<int, int> assembly, int totalRating, ePerson personType)
        {
            var persons = new List<TEntity>();
            foreach (var person in assembly)
                for (int i = 0; i < person.Value; i++)
                    persons.Add(PersonStrategyFactory<TEntity>.CreatePerson(personType, totalRating, person.Key));

            return persons;
        }

        protected internal virtual void AddPersonToAssembly(Dictionary<int, int> assembly)
        {
            assembly[assembly.Keys.ElementAt(RandomUtil.GetRandomInt(0, (assembly.Count - 1)))] += 1;
        }
    }
}
