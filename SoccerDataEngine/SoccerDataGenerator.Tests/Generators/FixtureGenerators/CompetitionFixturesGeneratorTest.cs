using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Generators.FixtureGenerators;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Tests.Generators.FixtureGenerators
{
    [TestFixture]
    public class CompetitionFixturesGeneratorTest
    {
        private CompetitionFixturesGenerator _generator;
        private Competition _competition;

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition{IdCompetition = 1, IdCountry = 1, MatchDays = new List<DayOfWeek> { DayOfWeek.Friday}, StartDate = new DateTime(2018, 6, 25)};
            _generator = new CompetitionFixturesGenerator(_competition);
        }

        [Test]
        public void CreateFixturesForCompetition_CreatesAllFixturesForCompetition() // stuck in loop
        {
            var teams = DataLists.Teams.Where(t => t.IdCompetition == _competition.IdCompetition).ToList();
            var allCombinations = _generator.CreateAllMatchCombinations(teams);
            var fixtures = _generator.CreateFixturesForCompetition(teams, allCombinations);
            Assert.IsNotEmpty(fixtures);
            Assert.AreEqual(teams.Count * (teams.Count -1), fixtures.Count);
        }

        [Test]
        public void GetGamesForMatchDay_ReturnsDictionaryWithMatchCombinationsForMatchDay()
        {
            var teams = DataLists.Teams.Where(t => t.IdCompetition == _competition.IdCompetition).ToList();
            var allCombinations = _generator.CreateAllMatchCombinations(teams);
            var gamesForMatchDay = _generator.GetGamesForMatchDay(allCombinations, teams.Count / 2);
            Assert.IsNotEmpty(gamesForMatchDay);
            Assert.AreEqual(teams.Count /2, gamesForMatchDay.Count);
        }

        [Test]
        public void AddDataToFixture_FixtureContainsAllNecessaryData()
        {
            var fixture = new Fixture{IdHomeTeam = 1, IdAwayTeam = 2};
            var matchDay = RandomUtil.GetRandomInt(1, 50);
            var idFixture = RandomUtil.GetRandomInt(1, 50);
            _generator.AddDataToFixture(fixture, matchDay, idFixture);
            Assert.IsNotNull(fixture);
            Assert.IsNotNull(fixture.Date);
            Assert.AreEqual(matchDay, fixture.IdMatchDay);
            Assert.AreEqual(idFixture, fixture.IdFixture);
        }

        [Test]
        public void CreateAllMatchCombinations_ReturnsAllCombinations()
        {
            var teams = DataLists.Teams.Where(t => t.IdCompetition == _competition.IdCompetition).ToList();
            var allCombinations =_generator.CreateAllMatchCombinations(teams);
            Assert.IsNotEmpty(allCombinations);
            Assert.AreEqual(typeof(List<MatchCombination>), allCombinations.GetType());
        }

        [Test]
        public void GetCompetitionStartDate_ReturnsFirstDateAfterCompetitionStartDateThatMatchesTheFirstMatchDay()
        {
            var startDate = _generator.GetCompetitionStartDate();
            Assert.IsNotNull(startDate);
            Assert.AreEqual(DayOfWeek.Friday, startDate.DayOfWeek);
            Assert.GreaterOrEqual(startDate, _competition.StartDate);
        }

        [Test]
        public void GetFixtureDate_ReturnsFixtureDate()
        {
            var matchDay = RandomUtil.GetRandomInt(1, 20);
            var fixtureDate = _generator.GetFixtureDate(matchDay);
            Assert.IsNotNull(fixtureDate);
            Assert.GreaterOrEqual(fixtureDate, _competition.StartDate.AddDays(matchDay * 7));
        }
    }
}
