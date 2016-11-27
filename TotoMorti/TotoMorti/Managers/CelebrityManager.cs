using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TotoMorti.Classes;
using TotoMorti.Interfaces;

namespace TotoMorti.Managers
{
    public class CelebrityManager
    {
        private readonly SQLiteAsyncConnection _connection;
        private readonly List<Celebrity> _fakeDb;

        public CelebrityManager(ISQLiteDb sqLiteDb)
        {
            _connection = sqLiteDb.GetConnection();
            _connection.CreateTableAsync<Celebrity>();


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

        public async Task<List<Celebrity>> GetAllCelebrities()
        {
            return await _connection.Table<Celebrity>().ToListAsync();
        }

        public async void AddCelebrity(Celebrity c)
        {
            await _connection.InsertAsync(c);
        }

        public async void DeleteCelebrity(Celebrity c)
        {
            await _connection.DeleteAsync(c);
        }

        public async void UpdateCelebrity(Celebrity c)
        {
            await _connection.UpdateAsync(c);
        }
    }
}