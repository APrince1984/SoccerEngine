using System;
using System.Collections.Generic;

namespace SoccerDataGenerator.Generators.AttributeGenerators
{
    public interface IAttributeGenerator
    {
        Dictionary<string, int> AddPersonAttributesByAttributeType(Type type, int totalRating, bool mainFunction);
    }
}