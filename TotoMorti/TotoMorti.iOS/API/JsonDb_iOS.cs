using System;
using System.IO;
using TotoMorti.iOS.API;
using TotoMorti.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace TotoMorti.iOS.API
{
    public class JsonDb_iOS : IJsonDb
    {
        private const string FileName = "totomorti.json";

        public void WriteJson(string s)
        {
            File.WriteAllText(GetPath(), s);
        }

        public string ReadJson()
        {
            return File.ReadAllText(GetPath());
        }

        private string GetPath()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            return Path.Combine(libraryPath, FileName);
        }
    }
}