using System.Collections.Generic;
using TotoMorti.Classes;

namespace TotoMorti.Managers
{
    public class CelebrityManager
    {
        private List<Celebrity> _fakeDb;

        public CelebrityManager()
        {
            _fakeDb = new List<Celebrity> { new Celebrity {Name="Kirk", Surname="Douglas", ImageUrl="http://cdn.inquisitr.com/wp-content/uploads/2014/12/kirk-douglas-100x100.jpg" },
           new Celebrity {Name="Beppe", Surname="Bigazzi", ImageUrl="http://www.newnotizie.it/wp-content/uploads/2010/02/bigazzi-100x100.jpg" },
           new Celebrity {Name="Valentino", Surname="Rossi", ImageUrl="http://www.litalianews.it/wp-content/uploads/2015/08/MotoGp-Valentino-Rossi-100x100.jpg" } };
        }

        public List<Celebrity> GetAllCelebrities()
        {
            return _fakeDb;
        }

        public void AddCelebrity(Celebrity c)
        {
            _fakeDb.Add(c);
        }
    }
}
