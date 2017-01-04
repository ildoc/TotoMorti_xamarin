﻿using System;
using System.IO;
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
        private const string FileName = "totomorti.json";

        public JsonDb_UWP()
        {
            if (!FileExists(FileName))
            {
                try
                {
                    ApplicationData.Current.LocalFolder.CreateFileAsync(FileName,
                        CreationCollisionOption.ReplaceExisting).AsTask().Wait();
                }
                catch (Exception e)
                {
                    
                }
            }
        }

        public string ReadJson()
        {
            var task = LoadTextAsync(FileName);
            task.Wait(); // HACK: to keep Interface return types simple (sorry!)
            return task.Result;
        }

        public async Task<string> LoadTextAsync(string filename)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
            string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            return text;
        }

        public async void WriteJson(string text)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, text);
        }

        bool FileExists(string filename)
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
