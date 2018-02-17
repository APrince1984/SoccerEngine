using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerDataGenerator.Data
{
    public class Player : Person
    {
        [ForeignKey("PlayerTeam")]
        public int? IdTeam { get; set; }

        public virtual Team PlayerTeam { get; set; }
        
        public List<int> Positions { get; set; }
        
        public int CurrentAbility { get; set; }

        public int PotentialAbility { get; set; }
        
    }
}
