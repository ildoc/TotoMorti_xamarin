using System;
using System.Collections.Generic;

namespace TotoMorti.Classes
{
    public class TotoList
    {
        public TotoList()
        {
            Categories.Add("Default Category");
        }

        public DateTime CreationDate { get; set; }
        public DateTime EditTimeLimit { get; set; }

        public List<string> Categories { get; set; } = new List<string>();
    }
}