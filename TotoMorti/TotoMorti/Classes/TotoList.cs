using System.Collections.Generic;

namespace TotoMorti.Classes
{
    public class TotoList
    {
        public List<string> Categories { get; set; } = new List<string>();

        public TotoList()
        {
            Categories.Add("Default Category");
        }
    }
}
