using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TotoMorti.Models;

namespace TotoMorti.Managers
{
    public class CategoryManager
    {
        private readonly JsonDbManager _jsonDbManager;

        public CategoryManager(JsonDbManager jsonDbManager)
        {
            _jsonDbManager = jsonDbManager;
        }

        public async Task SaveCategoryList(List<Category> categories, Guid listGuid)
        {
            await _jsonDbManager.SaveCategoryList(categories, listGuid);
        }

        public async Task DeleteCategory(Category category, Guid listGuid)
        {
            await _jsonDbManager.DeleteCategory(category, listGuid);
        }

        public async Task SaveCategory(Category category, Guid listGuid)
        {
            await _jsonDbManager.SaveCategory(category, listGuid);
        }

        public List<Celebrity> GetCelebritiesByGuid(List<string> currentCategoryCelebrityList)
        {
            return _jsonDbManager.GetCelebritiesByGuid(currentCategoryCelebrityList);
        }
    }
}