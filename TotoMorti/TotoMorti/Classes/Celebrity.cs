using SQLite;

namespace TotoMorti.Classes
{
    public class Celebrity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Surname { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public string FullName => $"{Name} {Surname}";
    }
}