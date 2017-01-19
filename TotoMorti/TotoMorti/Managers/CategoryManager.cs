using System;
using System.Collections.Generic;
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

        public void SaveCategoryList(List<Category> categories, Guid listGuid)
        {
            _jsonDbManager.SaveCategoryList(categories, listGuid);
        }

        public void DeleteCategory(Category category, Guid listGuid)
        {
            _jsonDbManager.DeleteCategory(category, listGuid);
        }

        public void SaveCategory(Category category, Guid listGuid)
        {
            _jsonDbManager.SaveCategory(category, listGuid);
        }

        public List<Celebrity> GetCelebritiesByGuid(List<string> currentCategoryCelebrityList)
        {
            return _jsonDbManager.GetCelebritiesByGuid(currentCategoryCelebrityList);
        }

        public void RemoveCelebrityFromCategory(Celebrity celebrity, Category category, Guid listGuid)
        {
            _jsonDbManager.RemoveCelebrityFromCategory(celebrity, category, listGuid);
        }
    }
}