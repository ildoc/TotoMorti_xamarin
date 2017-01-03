using SQLite;

namespace TotoMorti.Interfaces
{
    public interface IJsonDb
    {
        string ReadJson();
        void WriteJson(string s);
    }
}