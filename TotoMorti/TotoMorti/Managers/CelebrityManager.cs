using System;
using System.Collections.Generic;
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

        public void SaveCelebrity(Celebrity c)
        {
            _jsonDbManager.SaveCelebrity(c);
        }

        public void DeleteCelebrity(Celebrity c)
        {
            _jsonDbManager.DeleteCelebrity(c);
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