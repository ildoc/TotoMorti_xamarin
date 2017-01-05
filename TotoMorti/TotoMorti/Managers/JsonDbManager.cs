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
        private readonly List<Celebrity> _celebrities;

        private string totomortiDb = "totomorti";
        private string celebrityDb = "celebrity";

        public JsonDbManager(IJsonDb jsonDb)
        {
            _jsonDb = jsonDb;
            _totoLists = JsonConvert.DeserializeObject<List<TotoList>>(_jsonDb.ReadJson(totomortiDb)) ?? new List<TotoList>();
            _celebrities = JsonConvert.DeserializeObject<List<Celebrity>>(_jsonDb.ReadJson(celebrityDb)) ?? new List<Celebrity>();
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

            Save(totomortiDb);
        }

        private void Save(string dbName)
        {
            _jsonDb.WriteJson(JsonConvert.SerializeObject(_totoLists), dbName);
        }

        public void DeleteTotoList(TotoList totoList)
        {
            _totoLists.Remove(totoList);
            Save(totomortiDb);
        }

        public void SaveCategoryList(List<Category> categories, Guid listGuid)
        {
            var t = _totoLists.FirstOrDefault(x => x.ListGuid == listGuid);
            if (t != null)
            {
                t.Categories.Clear();
                t.Categories = categories;
            }
            Save(totomortiDb);
        }

        public IEnumerable<Celebrity> GetAllCelebrities()
        {
            return _celebrities;
        }

        public void SaveCelebrity(Celebrity celebrity)
        {
            var c = _celebrities.FirstOrDefault(x => x.CelebrityGuid == celebrity.CelebrityGuid);
            if (c != null)
            {
                c.Name = celebrity.Name;
                c.Surname = celebrity.Surname;
                c.ImageUrl = celebrity.ImageUrl;
            }
            else
            {
                _celebrities.Add(celebrity);
            }

            Save(celebrityDb);
        }

        public void DeleteCelebrity(Celebrity celebrity)
        {
            _celebrities.Remove(celebrity);
            Save(celebrityDb);
        }
    }
}