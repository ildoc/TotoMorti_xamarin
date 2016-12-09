using System;
using System.Collections.Generic;
using SQLite;

namespace TotoMorti.Classes
{
    public class Session
    {
        [PrimaryKey]
        [AutoIncrement]
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