using System;

namespace SoccerDataGenerator.Data
{
    public class Fixture
    {
        public int IdFixture { get; set; }
        public int IdMatchDay { get; set; }
        public int IdHomeTeam { get; set; }
        public int IdAwayTeam { get; set; }
        public DateTime Date { get; set; }
        public int? GoalsHomeTeam { get; set; }
        public int? GoalsAwayTeam { get; set; }
    }
}
