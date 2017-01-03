using System;
using System.Collections.Generic;

namespace TotoMorti.Classes
{
    public class TotoList
    {
        public DateTime CreationDate { get; set; }
        public DateTime EditTimeLimit { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}