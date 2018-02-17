using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerDataGenerator.Data
{
    public class Staff : Person
    {
        [ForeignKey("StaffTeam")]
        public int? IdTeam { get; set; }

        public virtual Team StaffTeam { get; set; }

        public int MainFunction { get; set; }

        public int CurrentAbility { get; set; }

        public int PotentialAbility { get; set; }
    }
}
