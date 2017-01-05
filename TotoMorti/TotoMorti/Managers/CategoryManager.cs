using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotoMorti.Classes;

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
    }
}
