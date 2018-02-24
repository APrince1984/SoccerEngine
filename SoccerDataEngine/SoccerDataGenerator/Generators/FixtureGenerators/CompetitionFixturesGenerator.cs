using System;
using System.Collections.Generic;
using System.Linq;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators.FixtureGenerators
{
    public class CompetitionFixturesGenerator : FixtureGeneratorBase<Competition>
    {
        public CompetitionFixturesGenerator(Competition competition) : base(competition)
        {
        }

        public override List<Fixture> GenerateFixtures()
        {
            var teamsInCompetition = DataLists.Teams.Where(t => t.IdCompetition == Obj.IdCompetition).ToList();
            var allMatchCombinations = CreateAllMatchCombinations(teamsInCompetition);
            return CreateFixturesForCompetition(teamsInCompetition, allMatchCombinations);
        }

        internal Dictionary<int, int> CreateAllMatchCombinations(List<Team> teams)
        {
            var homeTeams = teams;
            var awayTeams = teams;

            var combinations = new Dictionary<int, int>();
            foreach (var homeTeam in homeTeams)
            foreach (var awayTeam in awayTeams)
                if (homeTeam.IdTeam != awayTeam.IdTeam)
                    combinations.Add(homeTeam.IdTeam, awayTeam.IdTeam);

            return combinations;
        }

        internal List<Fixture> CreateFixturesForCompetition(List<Team> teamsInCompetition, Dictionary<int, int> allMatchCombinations)
        {
            var fixturesForCompetition = new List<Fixture>();
            var idFixture = 0;
            for (var matchDay = 0; matchDay < (teamsInCompetition.Count() - 1) * 2; matchDay++)
            {
                idFixture++;
                var gamesForMatchDay = GetGamesForMatchDay(allMatchCombinations, (teamsInCompetition.Count - 1) * 2);
                var matchDayFixtureGenerator = new MatchDayFixturesGenerator(gamesForMatchDay);
                var matchDayFixtures = matchDayFixtureGenerator.GenerateFixtures();
                foreach (var fixture in matchDayFixtures)
                    AddDataToFixture(fixture, matchDay, idFixture);

                fixturesForCompetition.AddRange(matchDayFixtures);
            }

            return fixturesForCompetition;
        }

        internal Dictionary<int, int> GetGamesForMatchDay(Dictionary<int, int> allMatchCombinations, int numberOfGamesOnMatchDay)
        {
            var gamesForMatchDay = new Dictionary<int, int>();
            for (var i = 0; i < numberOfGamesOnMatchDay; i++)
            {
                var gameForMatchDay = RandomUtil.GetRandomDictionary(allMatchCombinations);
                gamesForMatchDay.Add(gameForMatchDay.First().Key, gameForMatchDay.First().Value);
                allMatchCombinations.Remove(gameForMatchDay.First().Key);
            }

            return gamesForMatchDay;
        }

        internal void AddDataToFixture(Fixture fixture, int matchDay, int idFixture)
        {
            fixture.IdFixture = idFixture;
            fixture.IdMatchDay = matchDay;
            fixture.Date = GetFixtureDate(matchDay);
        }

        internal DateTime GetFixtureDate(int matchDay)
        {
            return GetCompetitionStartDate().AddDays(matchDay * 7);
        }

        internal DateTime GetCompetitionStartDate()
        {
            var startDate = Obj.StartDate;
            while (Obj.StartDate.DayOfWeek != Obj.MatchDays[0])
                startDate.AddDays(1);
            return startDate;
        }
    }
}