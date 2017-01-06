using System;

namespace TotoMorti.Models
{
    public class Celebrity
    {
        public Celebrity()
        {
            CelebrityGuid = Guid.NewGuid();
        }

        public Guid CelebrityGuid { get; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }

        public int Age
        {
            get
            {
                var age = DateTime.Now.Year - BirthDate.Year;
                if (BirthDate > DateTime.Now.AddYears(-age))
                    age--;
                return age;
            }
        }

        public string FullName => $"{Name} {Surname}";
    }
}