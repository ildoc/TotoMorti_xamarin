using System;
using System.Collections.Generic;

namespace TotoMorti.Classes
{
    public class Session
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StopEntryDate { get; set; }
        public int MaxCelebrityPerCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}