using System.Collections.Generic;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators.AssemblyGenerators
{
    public class SquadAssemblyGeneratorStrategy : AssemblyGeneratorBase<Player>
    {
        public SquadAssemblyGeneratorStrategy()
        {
            NumberOfPersonsInAssembly = 20;
        }

        protected internal override Dictionary<int, int> BuildAssembly()
        {
            return new Dictionary<int, int>
            {
                { Position.Goaly, RandomUtil.GetRandomInt(2, 3) },
                { Position.Defence, RandomUtil.GetRandomInt(5, 7) },
                { Position.Midfield, RandomUtil.GetRandomInt(5, 7) },
                { Position.Forward, RandomUtil.GetRandomInt(3, 4) },
            };
        }
    }
}
