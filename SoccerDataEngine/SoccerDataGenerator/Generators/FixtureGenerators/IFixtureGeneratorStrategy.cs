using System.Collections.Generic;
using SoccerDataGenerator.Data;

namespace SoccerDataGenerator.Generators.FixtureGenerators
{
    public interface IFixtureGeneratorStrategy
    {
        List<Fixture> GenerateFixtures(Competition competition, int competitionYear);
    }
}
