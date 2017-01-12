using System.Threading.Tasks;

namespace TotoMorti.Interfaces
{
    public interface IJsonDb
    {
        string ReadJson(string dbName);
        Task WriteJsonAsync(string s, string dbName);
    }
}