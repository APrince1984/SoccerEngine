using System.Collections.Generic;
using SoccerDataGenerator.Data;

namespace SoccerDataGenerator.Generators.FixtureGenerators
{
    public abstract class FixtureGeneratorBase<TObject>
    {
        protected readonly TObject Obj;

        protected FixtureGeneratorBase(TObject obj)
        {
            Obj = obj;
        }

        public abstract List<Fixture> GenerateFixtures();
    }
}
