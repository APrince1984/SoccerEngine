using System.ComponentModel.DataAnnotations.Schema;

namespace YouthGenerator.Data
{
    public class Team
    {
        public int IdTeam { get; set; }

        public string Name { get; set; }

        [ForeignKey("TeamRating")]
        public int Rating { get; set; }

        public virtual Rating TeamRating { get; set; }

        [ForeignKey("TeamCompetition")]
        public int IdCompetition { get; set; }

        public virtual Competition TeamCompetition { get; set; }
    }
}
