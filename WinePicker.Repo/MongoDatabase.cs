using MongoDB.Driver;
using System.Collections.Generic;
using WinePicker.Shared.Models;

namespace WinePicker.Repo
{
    public class MongoDatabase
    {
        private const string CONNECTION_STRING = "mongodb://127.0.0.1:27017";
        private const string DB_NAME = "WinePicker";
        private const string WINE_COLLECTION = "Wine";

        public List<WineModel> GetAllWines()
        {
            MongoClient client = new MongoClient(CONNECTION_STRING);

            var db = client.GetDatabase(DB_NAME);

            var wines = db.GetCollection<WineModel>(WINE_COLLECTION);

            return wines.Find("{}").ToList();
        }
    }
}