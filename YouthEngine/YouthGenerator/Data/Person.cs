using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouthGenerator.Data
{
    public class Person
    {
        public int IdPerson { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [ForeignKey("PersonNationality")]
        public int IdNationality { get; set; }

        public virtual Country PersonNationality { get; set; }
    }
}
