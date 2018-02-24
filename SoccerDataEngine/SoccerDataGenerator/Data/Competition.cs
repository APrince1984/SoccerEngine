using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerDataGenerator.Data
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

        public DateTime StartDate { get; set; }

        public DateTime? StartWinterStop { get; set; }

        public int NumberOfWinterStopDays { get; set; }

        public int NumberOfPromoters { get; set; }

        public int NumberOfDegradaters { get; set; }

        public List<DayOfWeek> MatchDays { get; set; }
    }
}
