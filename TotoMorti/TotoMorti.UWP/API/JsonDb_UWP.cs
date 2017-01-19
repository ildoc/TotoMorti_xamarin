using System;
using System.Threading.Tasks;
using Windows.Storage;
using TotoMorti.Interfaces;
using TotoMorti.UWP.API;
using Xamarin.Forms;

[assembly: Dependency(typeof(JsonDb_UWP))]

namespace TotoMorti.UWP.API
{
    public class JsonDb_UWP : IJsonDb
    {
        public string ReadJson(string dbName)
        {
            if (!FileExists(dbName + ".json"))
            {
                ApplicationData.Current.LocalFolder.CreateFileAsync(dbName + ".json",
                    CreationCollisionOption.ReplaceExisting).AsTask().Wait();
                return "";
            }
            var task = LoadTextAsync(dbName + ".json");
            task.Wait(); // HACK: to keep Interface return types simple (sorry!)
            return task.Result;
        }

        public async Task WriteJsonAsync(string text, string dbName)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var sampleFile = await localFolder.CreateFileAsync(dbName + ".json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, text);
        }

        public async Task<string> LoadTextAsync(string filename)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var sampleFile = await storageFolder.GetFileAsync(filename);
            var text = await FileIO.ReadTextAsync(sampleFile);
            return text;
        }

        private bool FileExists(string filename)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                localFolder.GetFileAsync(filename).AsTask().Wait();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}