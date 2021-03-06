﻿using System.Collections.Generic;
using SoccerDataGenerator.Data;

namespace SoccerDataGenerator.Generators.AssemblyGenerators
{
    public interface IAssemblyGenerator<TEntity>
    {
        List<TEntity> GenerateAssembly(ePerson personType, int countryRating, int? competitionRation = null, int? teamRating = null);
    }
}