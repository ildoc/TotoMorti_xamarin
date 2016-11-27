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
        public SQLiteAsyncConnection GetConnection()
        {
            const string fileName = "totomorti.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            return new SQLiteAsyncConnection(path);
        }
    }
}