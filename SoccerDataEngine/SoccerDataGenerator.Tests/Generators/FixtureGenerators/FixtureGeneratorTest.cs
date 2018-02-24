using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Generators.FixtureGenerators;

namespace SoccerDataGenerator.Tests.Generators.FixtureGenerators
{
    [TestFixture]
    public class FixtureGeneratorTest
    {
        [Test]
        public void CreateWeekFixtureMatchCombination_ReturnsMatchCombination_RemoveCombinationFromListOfMatchCombinations()
        {
            var matchCombinations = CreateMatchCombinationList();
            var homeTeamIds = new List<int> {1, 2};
            var awayTeamIds = new List<int> {3, 4};
            var generator = new FixtureGenerator();
            var index = 0;
            foreach (var id in homeTeamIds)
            {
                var fixtureCombination = generator.CreateWeekFixtureMatchCombination(matchCombinations, homeTeamIds, awayTeamIds, index);
                Assert.IsNotNull(fixtureCombination);
                Assert.IsFalse(matchCombinations.Contains(fixtureCombination));
                index++;
            }
            
        }

        private static List<MatchCombination> CreateMatchCombinationList()
        {
            return new List<MatchCombination>
            {
                { new MatchCombination { IdHomeTeam = 1, IdAwayTeam = 2 } },
                { new MatchCombination { IdHomeTeam = 1, IdAwayTeam = 3 } },
                { new MatchCombination { IdHomeTeam = 1, IdAwayTeam = 4 } },
                { new MatchCombination { IdHomeTeam = 2, IdAwayTeam = 1 } },
                { new MatchCombination { IdHomeTeam = 2, IdAwayTeam = 3 } },
                { new MatchCombination { IdHomeTeam = 2, IdAwayTeam = 4 } },
                { new MatchCombination { IdHomeTeam = 3, IdAwayTeam = 1 } },
                { new MatchCombination { IdHomeTeam = 3, IdAwayTeam = 2 } },
                { new MatchCombination { IdHomeTeam = 3, IdAwayTeam = 4 } },
                { new MatchCombination { IdHomeTeam = 4, IdAwayTeam = 1 } },
                { new MatchCombination { IdHomeTeam = 4, IdAwayTeam = 2 } },
                { new MatchCombination { IdHomeTeam = 4, IdAwayTeam = 3 } }
            };
        }

        [Test]
        public void GetHomeTeamIds_ReturnsListOfIds()
        {
            var generator = new FixtureGenerator();
            var teams = DataLists.Teams.Where(t => t.IdCompetition == 1).ToList();
            var ids = generator.GetHomeTeamIds(teams, teams.Count / 2);
            Assert.AreEqual(teams.Count /2, ids.Count);

            var allTeamIds = teams.Select(t => t.IdTeam).ToList();
            foreach (var id in ids)
            {
                Assert.IsTrue(allTeamIds.Contains(id));             // All returned Id's are in teamIds
                Assert.AreEqual(1, ids.Count(i => i == id));        // No Doubles
            }
        }

        [Test]
        public void CreateAllMatchCombinations_returnsAllMatchCombinations()
        {
            var teams = DataLists.Teams.Where(t => t.IdCompetition == 1).ToList();
            var generator = new FixtureGenerator();
            var combinations = generator.CreateAllMatchCombinations(teams);
            Assert.AreEqual(teams.Count * (teams.Count -1), combinations.Count);
        }

        [Test]
        public void CreateAllMatchCombinations_NoTeamsInList_returnsEmtpyListCombinations()
        {
            var teams = new List<Team>();
            var generator = new FixtureGenerator();
            var combinations = generator.CreateAllMatchCombinations(teams);
            Assert.IsEmpty(combinations);
            Assert.AreEqual(0, combinations.Count);
        }
    }
}
