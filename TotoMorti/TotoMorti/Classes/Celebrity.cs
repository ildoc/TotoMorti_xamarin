namespace TotoMorti.Classes
{
    public class Celebrity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }

        public string FullName { get { return $"{Name} {Surname}"; } }
    }
}
