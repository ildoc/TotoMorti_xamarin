using SQLite;
using TotoMorti.Interfaces;

namespace TotoMorti.Tests
{
    public class TestSqliteDb : ISQLiteDb
    {
        private const string FileName = "totomorti.db3";

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(FileName);
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(FileName);
        }
    }
}