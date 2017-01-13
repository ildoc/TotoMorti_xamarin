using System.Collections.Generic;

namespace TotoMorti.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<User> Users { get; set; }

        public ICollection<Session> Sessions { get; set; } = new List<Session>();
        public User GroupOwner { get; set; }
    }
}