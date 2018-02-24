using System;
using System.Collections.Generic;
using System.Linq;
using SoccerDataGenerator.Data;
using SoccerDataGenerator.Utils;

namespace SoccerDataGenerator.Generators.FixtureGenerators
{
    public class FixtureGenerator : IFixtureGeneratorStrategy
    {
        public List<Fixture> GenerateFixtures(Competition competition, int competitionYear)
        {
            var teamsInCompetition = DataLists.Teams.Where(t => t.IdCompetition == competition.IdCompetition).ToList();
            var numberOfMatchDays = (teamsInCompetition.Count() - 1) * 2;
            var numberOfHomeTeamsPerFixture = teamsInCompetition.Count / 2;
            var firstFixtureDate = GetFirstFixtureDate(competition, competitionYear);
            var fixtures = new List<Fixture>();
            var matchCombinations = CreateAllMatchCombinations(teamsInCompetition);
            for (var matchDay = 0; matchDay < numberOfMatchDays; matchDay++)
            {
                var homeTeamIds = GetHomeTeamIds(teamsInCompetition, numberOfHomeTeamsPerFixture);
                var awayTeamIds = teamsInCompetition.Select(t => t.IdTeam).Where(i => !homeTeamIds.Contains(i)).ToList();
                var weekFixtureCombinations = new List<MatchCombination>();
                for (var i = 0; i < numberOfHomeTeamsPerFixture; i++)
                    weekFixtureCombinations.Add(CreateWeekFixtureMatchCombination(matchCombinations, homeTeamIds, awayTeamIds, i));
                
            }

            return null;
        }

        protected internal MatchCombination CreateWeekFixtureMatchCombination(List<MatchCombination> matchCombinations, List<int> homeTeamIds, List<int> awayTeamIds, int index)
        {
            var awayTeamIdIndex = RandomUtil.GetRandomInt(0, homeTeamIds.Count - 1);
            var combination = new MatchCombination { IdHomeTeam = homeTeamIds[index], IdAwayTeam = awayTeamIds[awayTeamIdIndex] };
            while (matchCombinations.FirstOrDefault(mc => mc.IdHomeTeam == combination.IdHomeTeam && mc.IdAwayTeam == combination.IdAwayTeam) == null)
            {
                awayTeamIdIndex = RandomUtil.GetRandomInt(0, homeTeamIds.Count - 1);
                combination = new MatchCombination { IdHomeTeam = homeTeamIds[index], IdAwayTeam = awayTeamIds[awayTeamIdIndex] };
            }
            
            matchCombinations.Remove(matchCombinations.FirstOrDefault(mc => mc.IdHomeTeam == combination.IdHomeTeam && mc.IdAwayTeam == combination.IdAwayTeam));
            return new MatchCombination { IdHomeTeam = homeTeamIds[index], IdAwayTeam = awayTeamIds[index] };
        }

        protected internal List<int> GetHomeTeamIds(List<Team> teams, int numberOfHomeTeams)
        {
            var homeTeamIds = new List<int>();
            for (var i = 0; i < numberOfHomeTeams; i++)
            {
                var teamId = RandomUtil.GetRandomObject(teams).IdTeam;
                while (homeTeamIds.Contains(teamId))
                    teamId = RandomUtil.GetRandomObject(teams).IdTeam;

                homeTeamIds.Add(teamId);
            }
            
            return homeTeamIds;
        }

        private static DateTime GetFirstFixtureDate(Competition competition, int year)
        {
            var firstFixtureDate = new DateTime(year, competition.StartDate.Month, competition.StartDate.Day);
            while (firstFixtureDate.DayOfWeek != competition.MatchDays[0])
                firstFixtureDate.AddDays(1);
            return firstFixtureDate.Date;
        }

        protected internal List<MatchCombination> CreateAllMatchCombinations(List<Team> teams)
        {
            var homeTeams = teams;
            var awayTeams = teams;

            var combinations = new List<MatchCombination>();
            foreach (var homeTeam in homeTeams)
                foreach (var awayTeam in awayTeams)
                    if (homeTeam.IdTeam != awayTeam.IdTeam) 
                        combinations.Add(new MatchCombination{ IdHomeTeam = homeTeam.IdTeam, IdAwayTeam = awayTeam.IdTeam});

            return combinations;
        }
    }
}
