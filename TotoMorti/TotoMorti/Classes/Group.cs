using System.Collections.Generic;
using SQLite;

namespace TotoMorti.Classes
{
    public class Group
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<User> Users { get; set; }
        public List<Category> Categories { get; set; }
        public User GroupOwner { get; set; }
    }
}