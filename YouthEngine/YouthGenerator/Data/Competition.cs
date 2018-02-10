using System.ComponentModel.DataAnnotations.Schema;

namespace YouthGenerator.Data
{
    public class Competition
    {
        public int IdCompetition { get; set; }

        public string Name { get; set; }

        [ForeignKey("CompetitionRating")]
        public int Rating { get; set; }

        public virtual Rating CompetitionRating { get; set; }

        [ForeignKey("CompetitionCountry")]
        public int IdCountry { get; set; }

        public virtual Country CompetitionCountry { get; set; }
    }
}
