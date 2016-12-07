using System;
using System.IO;
using SQLite;
using TotoMorti.Droid.API;
using TotoMorti.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb_Android))]

namespace TotoMorti.Droid.API
{
    public class SQLiteDb_Android : ISQLiteDb
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
            return Path.Combine(documentPath, FileName);
        }
    }
}