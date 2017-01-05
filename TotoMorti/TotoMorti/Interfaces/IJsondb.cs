namespace TotoMorti.Interfaces
{
    public interface IJsonDb
    {
        string ReadJson(string dbName);
        void WriteJson(string s, string dbName);
    }
}