using SQLite;

namespace TotoMorti.Interfaces
{
    public interface ISQLiteDb
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetConnectionAsync();
    }
}