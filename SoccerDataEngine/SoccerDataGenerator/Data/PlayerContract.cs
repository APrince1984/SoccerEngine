using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerDataGenerator.Data
{
    public class PlayerContract
    {
        public int IdPlayerContract { get; set; }

        [ForeignKey("PlayerContractPlayer")]
        public int IdPlayer { get; set; }

        public virtual Player PlayerContractPlayer { get; set; }

        [ForeignKey("PlayerContractContract")]
        public int? IdContract { get; set; }

        public virtual Contract PlayerContractContract { get; set; }
    }
}
