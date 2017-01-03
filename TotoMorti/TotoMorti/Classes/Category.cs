using System;

namespace TotoMorti.Classes
{
    public class Category
    {
        public Category()
        {
            CategoryGuid = Guid.NewGuid();
        }

        public Guid CategoryGuid { get; }
        public string Title { get; set; }
        // public string Description { get; set; }
        public string VipList { get; set; }
    }
}