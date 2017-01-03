namespace TotoMorti.Classes
{
    public class Celebrity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string ImageUrl { get; set; }

        public string FullName => $"{Name} {Surname}";
    }
}