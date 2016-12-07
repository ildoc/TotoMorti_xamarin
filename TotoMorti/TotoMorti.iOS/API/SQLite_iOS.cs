using System;
using System.IO;
using SQLite;
using TotoMorti.iOS.API;
using TotoMorti.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace TotoMorti.iOS.API
{
    public class SQLite_iOS : ISQLiteDb
    {
        private const string FileName = "totomorti.db3";

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(GetPath());
        }

        private string GetPath()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            return Path.Combine(libraryPath, FileName);
        }
    }
}