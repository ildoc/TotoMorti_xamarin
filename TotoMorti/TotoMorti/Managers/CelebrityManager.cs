using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TotoMorti.Models;

namespace TotoMorti.Managers
{
    public class CelebrityManager
    {
        private readonly JsonDbManager _jsonDbManager;

        public CelebrityManager(JsonDbManager jsonDbManager)
        {
            _jsonDbManager = jsonDbManager;
        }

        public IEnumerable<Celebrity> GetAllCelebrities()
        {
            return _jsonDbManager.GetAllCelebrities();
        }

        public async Task SaveCelebrity(Celebrity c)
        {
            await _jsonDbManager.SaveCelebrity(c);
        }

        public async Task DeleteCelebrity(Celebrity c)
        {
            await _jsonDbManager.DeleteCelebrity(c);
        }

        public void UpdateCelebrity(Celebrity c)
        {
            // _connection.Update(c);
        }

        public List<string> ResolveCelebrityList(Category cat, Guid listGuid)
        {
            return _jsonDbManager.ResolveCelebrityList(cat, listGuid);
        }

        public List<Celebrity> GetAvailableCelebrities(List<Celebrity> selectedCelebrities)
        {
            return _jsonDbManager.GetAvailableCelebrities(selectedCelebrities);
        }
    }
}