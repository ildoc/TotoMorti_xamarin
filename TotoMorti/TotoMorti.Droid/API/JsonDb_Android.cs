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
        private const string FileName = "totomorti.json";

        public JsonDb_Android()
        {
            if (!File.Exists(GetPath()))
                File.Create(GetPath()).Dispose();
        }

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
            return Path.Combine(documentPath, FileName);
        }
    }
}