using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TotoMorti.Models
{
    public class Category
    {
        public Category()
        {
            CategoryGuid = Guid.NewGuid();
            CelebrityList = new List<string>();
            ResolvedCelebrityList = new List<string>();
        }

        public Guid CategoryGuid { get; set; }
        public string Title { get; set; }
        // public string Description { get; set; }
        public List<string> CelebrityList { get; set; }

        [JsonIgnore]
        public List<string> ResolvedCelebrityList { get; set; }
    }
}