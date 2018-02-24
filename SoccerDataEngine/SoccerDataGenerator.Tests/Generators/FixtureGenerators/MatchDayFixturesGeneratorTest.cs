using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Generators.FixtureGenerators;

namespace SoccerDataGenerator.Tests.Generators.FixtureGenerators
{
    [TestFixture]
    public class MatchDayFixturesGeneratorTest
    {
        private MatchDayFixturesGenerator _generator;
        private Dictionary<int, int> _matchCombinations;

        [SetUp]
        public void SetUp()
        {
            _matchCombinations = new Dictionary<int, int> { { 1, 2 }, { 3, 4 }, {5, 6} };
            _generator = new MatchDayFixturesGenerator(_matchCombinations);
        }
        

        [Test]
        public void CreateOnFixture_ReturnsOneFixture()
        {
            var fixture = _generator.CreateOneFixture(1, 2);
            Assert.IsNotNull(fixture);
            Assert.AreEqual(typeof(Fixture), fixture.GetType());
            Assert.AreEqual(1, fixture.IdHomeTeam);
            Assert.AreEqual(2, fixture.IdAwayTeam);
        }

        [Test]
        public void GenerateFixtures_ReturnsAllFixturesForMatchDay()
        {
            var fixtures = _generator.GenerateFixtures();
            Assert.IsNotEmpty(fixtures);
            Assert.AreEqual(typeof(List<Fixture>), fixtures.GetType());
            Assert.AreEqual(3, fixtures.Count);
            foreach (var element in _matchCombinations)
                Assert.IsNotNull(fixtures.FirstOrDefault(f => f.IdHomeTeam == element.Key && f.IdAwayTeam == element.Value));
            
        }
    }
}
