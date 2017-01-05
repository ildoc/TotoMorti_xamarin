using System;
using System.IO;
using TotoMorti.iOS.API;
using TotoMorti.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(JsonDb_iOS))]

namespace TotoMorti.iOS.API
{
    public class JsonDb_iOS : IJsonDb
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
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            return Path.Combine(libraryPath, dbName+".json");
        }
    }
}