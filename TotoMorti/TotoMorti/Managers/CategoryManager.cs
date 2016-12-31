using System.Collections.Generic;
using System.Linq;
using SQLite;
using TotoMorti.Classes;
using TotoMorti.Interfaces;

namespace TotoMorti.Managers
{
    public class CategoryManager
    {
        private readonly SQLiteConnection _connection;

        public CategoryManager(ISQLiteDb sqLiteDb)
        {
            _connection = sqLiteDb.GetConnection();
            _connection.CreateTable<Category>();
        }

        public List<Category> GetAllCategories()
        {
            return _connection.Table<Category>().ToList();
        }

        public void AddCategory(Category c)
        {
            _connection.Insert(c);
        }

        public void DeleteCategory(Category c)
        {
            _connection.Delete(c);
        }

        public void UpdateCategory(Category c)
        {
            _connection.Update(c);
        }

        public void SaveCategoryList(List<Category> categoryList)
        {
            _connection.DeleteAll<Category>();
            _connection.InsertAll(categoryList);
        }
    }
}