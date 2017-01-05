using System;

namespace TotoMorti.Classes
{
    public class Celebrity
    {
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
                int age = DateTime.Now.Year - BirthDate.Year;
                if (BirthDate > DateTime.Now.AddYears(-age))
                    age--;
                return age;
            }
        }

        public string FullName => $"{Name} {Surname}";

        public Celebrity()
        {
            CelebrityGuid=Guid.NewGuid();
        }
    }
}