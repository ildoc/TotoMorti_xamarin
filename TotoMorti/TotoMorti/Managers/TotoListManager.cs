using System.Collections.Generic;
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

        public void SaveTotoList(TotoList currentTotoList)
        {
            _jsonDbManager.SaveTotoList(currentTotoList);
        }

        public IEnumerable<TotoList> GetAllTotoLists()
        {
            return _jsonDbManager.GetAllTotoLists();
        }

        public void DeleteTotoList(TotoList totoList)
        {
            _jsonDbManager.DeleteTotoList(totoList);
        }
    }
}