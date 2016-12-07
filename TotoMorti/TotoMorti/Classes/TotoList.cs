using System.Collections.Generic;

namespace TotoMorti.Classes
{
    public class TotoList
    {
        public TotoList()
        {
            Categories.Add("Default Category");
        }

        public List<string> Categories { get; set; } = new List<string>();
    }
}