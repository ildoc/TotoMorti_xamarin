using System.Collections.Generic;
using System.Threading.Tasks;
using TotoMorti.Models;

namespace TotoMorti.Managers
{
    public class TotoListManager
    {
        private readonly JsonDbManager _jsonDbManager;

        public TotoListManager(JsonDbManager jsonDbManager)
        {
            _jsonDbManager = jsonDbManager;
        }

        public async Task SaveTotoList(TotoList currentTotoList)
        {
            await _jsonDbManager.SaveTotoList(currentTotoList);
        }

        public IEnumerable<TotoList> GetAllTotoLists()
        {
            return _jsonDbManager.GetAllTotoLists();
        }

        public async Task DeleteTotoList(TotoList totoList)
        {
            await _jsonDbManager.DeleteTotoList(totoList);
        }
    }
}