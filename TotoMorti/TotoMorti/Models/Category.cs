using System;
using System.Collections.Generic;

namespace TotoMorti.Models
{
    public class Category
    {
        public Category()
        {
            CategoryGuid = Guid.NewGuid();
            CelebrityList = new List<string>();
        }

        public Guid CategoryGuid { get; }
        public string Title { get; set; }
        // public string Description { get; set; }
        public List<string> CelebrityList { get; set; }
    }
}