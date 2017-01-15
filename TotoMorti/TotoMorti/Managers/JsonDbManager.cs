using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TotoMorti.Interfaces;
using TotoMorti.Models;

namespace TotoMorti.Managers
{
    public class JsonDbManager
    {
        private const string celebrityDb = "celebrity";
        private const string totomortiDb = "totomorti";
        private readonly List<Celebrity> _celebrities;
        private readonly IJsonDb _jsonDb;
        private readonly List<TotoList> _totoLists;

        public JsonDbManager(IJsonDb jsonDb)
        {
            _jsonDb = jsonDb;
            _totoLists = JsonConvert.DeserializeObject<List<TotoList>>(_jsonDb.ReadJson(totomortiDb)) ??
                         new List<TotoList>();
            _celebrities = JsonConvert.DeserializeObject<List<Celebrity>>(_jsonDb.ReadJson(celebrityDb)) ??
                           new List<Celebrity>();
        }

        public IEnumerable<TotoList> GetAllTotoLists()
        {
            return _totoLists;
        }

        public async Task SaveTotoList(TotoList totoList)
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

            await Save(totomortiDb);
        }

        private async Task Save(string dbName)
        {
            switch (dbName)
            {
                case celebrityDb:
                    await _jsonDb.WriteJsonAsync(JsonConvert.SerializeObject(_celebrities), dbName);
                    break;
                case totomortiDb:
                    await _jsonDb.WriteJsonAsync(JsonConvert.SerializeObject(_totoLists), dbName);
                    break;
            }
        }

        public async Task DeleteTotoList(TotoList totoList)
        {
            await Task.Run(() => _totoLists.Remove(totoList));
            await Save(totomortiDb);
        }

        public async Task SaveCategoryList(List<Category> categories, Guid listGuid)
        {
            var t = _totoLists.FirstOrDefault(x => x.ListGuid == listGuid);
            if (t != null)
            {
                t.Categories.Clear();
                t.Categories = categories;
            }
            await Save(totomortiDb);
        }

        public IEnumerable<Celebrity> GetAllCelebrities()
        {
            return _celebrities;
        }

        public async Task SaveCelebrity(Celebrity celebrity)
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

            await Save(celebrityDb);
        }

        public async Task DeleteCelebrity(Celebrity celebrity)
        {
            await Task.Run(() => _celebrities.Remove(celebrity));
            await Save(celebrityDb);
        }

        public List<Celebrity> GetAvailableCelebrities(List<Celebrity> selectedCelebrities)
        {
            return _celebrities.Except(selectedCelebrities).ToList();
        }

        public async Task SaveCategory(Category category, Guid listGuid)
        {
            var t = _totoLists.FirstOrDefault(x => x.ListGuid == listGuid);
            var c = t?.Categories.FirstOrDefault(x => x.CategoryGuid == category.CategoryGuid);
            if (c != null)
            {
                c.Title = category.Title;
                c.CelebrityList = category.CelebrityList;
            }
            else
            {
                t?.Categories.Add(category);
            }
            await Save(totomortiDb);
        }

        public List<Celebrity> GetCelebritiesByGuid(List<string> categoryCelebrityList)
        {
            return _celebrities.Where(x => categoryCelebrityList.Contains(x.CelebrityGuid.ToString())).ToList();
        }

        public List<string> ResolveCelebrityList(Category cat, Guid listGuid)
        {
            var t = _totoLists.FirstOrDefault(x => x.ListGuid == listGuid);
            var c = t?.Categories.FirstOrDefault(x => x.CategoryGuid == cat.CategoryGuid);
            if (c != null)
            {
                var res = GetCelebritiesByGuid(cat.CelebrityList).Select(x => x.FullName).ToList();
                return res;
            }
            return new List<string>();
        }

        public async Task DeleteCategory(Category category, Guid listGuid)
        {
            var t = _totoLists.FirstOrDefault(x => x.ListGuid == listGuid);
            await Task.Run(() => t?.Categories.Remove(category));
        }
    }
}