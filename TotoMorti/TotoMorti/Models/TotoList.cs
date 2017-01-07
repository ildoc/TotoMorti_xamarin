﻿using System;
using System.Collections.Generic;
using TotoMorti.Resx;

namespace TotoMorti.Models
{
    public class TotoList
    {
        public TotoList()
        {
            ListGuid = Guid.NewGuid();
            CreationDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
        }

        public Guid ListGuid { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditTimeLimit { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxItemPerCategory { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

        public string CreatedOn => $"{AppResources.CreatedOn} {CreationDate:d}";
    }
}