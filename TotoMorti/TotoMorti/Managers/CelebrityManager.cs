using System.Collections.Generic;
using System.Linq;
using SQLite;
using TotoMorti.Classes;
using TotoMorti.Interfaces;

namespace TotoMorti.Managers
{
    public class CelebrityManager
    {
        private readonly SQLiteConnection _connection;
        private readonly List<Celebrity> _fakeDb;

        public CelebrityManager(ISQLiteDb sqLiteDb)
        {
            _connection = sqLiteDb.GetConnection();
            _connection.CreateTable<Celebrity>();


            //_fakeDb = new List<Celebrity>
            //{
            //    new Celebrity
            //    {
            //        Name = "Kirk",
            //        Surname = "Douglas",
            //        ImageUrl = "http://cdn.inquisitr.com/wp-content/uploads/2014/12/kirk-douglas-100x100.jpg"
            //    },
            //    new Celebrity
            //    {
            //        Name = "Beppe",
            //        Surname = "Bigazzi",
            //        ImageUrl = "http://www.newnotizie.it/wp-content/uploads/2010/02/bigazzi-100x100.jpg"
            //    },
            //    new Celebrity
            //    {
            //        Name = "Valentino",
            //        Surname = "Rossi",
            //        ImageUrl = "http://www.litalianews.it/wp-content/uploads/2015/08/MotoGp-Valentino-Rossi-100x100.jpg"
            //    }
            //};
        }

        public List<Celebrity> GetAllCelebrities()
        {
            return _connection.Table<Celebrity>().ToList();
        }

        public void AddCelebrity(Celebrity c)
        {
            _connection.Insert(c);
        }

        public void DeleteCelebrity(Celebrity c)
        {
            _connection.Delete(c);
        }

        public void UpdateCelebrity(Celebrity c)
        {
            _connection.Update(c);
        }
    }
}