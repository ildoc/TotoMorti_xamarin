using System;
using System.Collections.Generic;

namespace TotoMorti.Classes
{
    public class TotoList
    {
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditTimeLimit { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

        public string CreatedOn => $"{Resx.AppResources.CreatedOn} {CreationDate:d}";
    }
}