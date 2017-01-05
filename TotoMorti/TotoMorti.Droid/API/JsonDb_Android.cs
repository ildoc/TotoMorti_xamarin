using System;
using System.IO;
using TotoMorti.Droid.API;
using TotoMorti.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(JsonDb_Android))]

namespace TotoMorti.Droid.API
{
    public class JsonDb_Android : IJsonDb
    {
        public void WriteJson(string s, string dbName)
        {
            File.WriteAllText(GetPath(dbName), s);
        }

        public string ReadJson(string dbName)
        {
            if (!File.Exists(GetPath(dbName)))
                return "";
            return File.ReadAllText(GetPath(dbName));
        }

        private string GetPath(string dbName)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(documentPath, dbName+".json");
        }
    }
}