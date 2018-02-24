using System.Collections.Generic;
using SoccerDataGenerator.Data;

namespace SoccerDataGenerator.Generators.FixtureGenerators
{
    public class MatchDayFixturesGenerator : FixtureGeneratorBase<Dictionary<int, int>>
    {
        public MatchDayFixturesGenerator(Dictionary<int, int> games) : base(games)
        {
        }

        public override List<Fixture> GenerateFixtures()
        {
            var matchDayFixtures = new List<Fixture>();
            foreach (var game in Obj)
                matchDayFixtures.Add(CreateOneFixture(game.Key, game.Value));
            return matchDayFixtures;
        }

        internal Fixture CreateOneFixture(int idHomeTeam, int idAwayTeam)
        {
            return new Fixture
            {
                IdHomeTeam = idHomeTeam,
                IdAwayTeam = idAwayTeam,
            };
        }
    }
}
