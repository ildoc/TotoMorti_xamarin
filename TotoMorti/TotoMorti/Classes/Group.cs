using System.Collections.Generic;

namespace TotoMorti.Classes
{
    public class Group
    {
        public string Title { get; set; }
        public List<User> Users { get; set; }
        public List<Category> Categories { get; set; }
        public User GroupOwner { get; set; }
    }
}
