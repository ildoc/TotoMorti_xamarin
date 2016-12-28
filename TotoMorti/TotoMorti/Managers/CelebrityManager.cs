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

        public CelebrityManager(ISQLiteDb sqLiteDb)
        {
            _connection = sqLiteDb.GetConnection();
            _connection.CreateTable<Celebrity>();
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