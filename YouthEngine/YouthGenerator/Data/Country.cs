using System.ComponentModel.DataAnnotations.Schema;

namespace YouthGenerator.Data
{
    public class Country
    {
        public int IdCountry { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        [ForeignKey("CountryRating")]
        public int Rating { get; set; }

        public virtual Rating CountryRating { get; set; }
    }
}
