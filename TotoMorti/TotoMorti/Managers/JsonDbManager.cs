using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TotoMorti.Classes;
using TotoMorti.Interfaces;

namespace TotoMorti.Managers
{
    public class JsonDbManager
    {
        private readonly IJsonDb _jsonDb;
        private readonly List<TotoList> _totoLists;

        public JsonDbManager(IJsonDb jsonDb)
        {
            _jsonDb = jsonDb;
            _totoLists = JsonConvert.DeserializeObject<List<TotoList>>(_jsonDb.ReadJson()) ?? new List<TotoList>();
        }

        public IEnumerable<TotoList> GetAllTotoLists()
        {
            return _totoLists;
        }

        public void SaveTotoList(TotoList totoList)
        {
            var t = _totoLists.FirstOrDefault(x => x.ListGuid == totoList.ListGuid);
            if (t != null)
            {
                t.Categories = totoList.Categories;
                t.EditTimeLimit = totoList.EditTimeLimit;
                t.EndDate = totoList.EndDate;
                t.Title = totoList.Title;
            }
            else
            {
                _totoLists.Add(totoList);
            }

            Save();
        }

        private void Save()
        {
            _jsonDb.WriteJson(JsonConvert.SerializeObject(_totoLists));
        }

        public void DeleteTotoList(TotoList totoList)
        {
            _totoLists.Remove(totoList);
            Save();
        }

        public void SaveCategoryList(List<Category> categories, Guid listGuid)
        {
            var t = _totoLists.FirstOrDefault(x => x.ListGuid == listGuid);
            if (t != null)
            {
                t.Categories.Clear();
                t.Categories = categories;
            }
            Save();
        }
    }
}