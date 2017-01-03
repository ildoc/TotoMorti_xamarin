using System.Collections.Generic;
using Newtonsoft.Json;
using TotoMorti.Classes;
using TotoMorti.Interfaces;

namespace TotoMorti.Managers
{
    public class CategoryManager
    {
        //private readonly SQLiteConnection _connection;
        private readonly IJsonDb _jsonDb;

        public CategoryManager(IJsonDb jsonDb)
        {
            //_connection = sqLiteDb.GetConnection();
            //_connection.CreateTable<Category>();

            _jsonDb = jsonDb;
        }

        public List<Category> GetAllCategories()
        {
            return JsonConvert.DeserializeObject<List<Category>>(_jsonDb.ReadJson());
            //return _connection.Table<Category>().ToList();
        }

        //public void AddCategory(Category c)
        //{
        //    _connection.Insert(c);
        //}

        //public void DeleteCategory(Category c)
        //{
        //    _connection.Delete(c);
        //}

        //public void UpdateCategory(Category c)
        //{
        //    _connection.Update(c);
        //}

        public void SaveCategoryList(List<Category> categoryList)
        {
            _jsonDb.WriteJson(JsonConvert.SerializeObject(categoryList));

            //_connection.DeleteAll<Category>();
            //_connection.InsertAll(categoryList);
        }
    }
}