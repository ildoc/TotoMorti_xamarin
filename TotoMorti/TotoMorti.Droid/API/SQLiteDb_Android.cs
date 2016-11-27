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
        public SQLiteAsyncConnection GetConnection()
        {
            const string fileName = "totomorti.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, fileName);

            return new SQLiteAsyncConnection(path);
        }
    }
}