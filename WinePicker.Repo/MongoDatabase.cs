using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using WinePicker.Shared.Interfaces;
using WinePicker.Shared.Models;

namespace WinePicker.Repo
{
    public class MongoDatabase : IWineRepo
    {
        private const string CONNECTION_STRING = "mongodb://127.0.0.1:27017";
        private const string DB_NAME = "WinePicker";
        private const string WINE_COLLECTION = "wine";

        public async Task<List<WineModel>> GetAllWines()
        {
            MongoClient client = new MongoClient(CONNECTION_STRING);

            var db = client.GetDatabase(DB_NAME);

            var test = db.ListCollectionNames();

            var wines = db.GetCollection<WineModel>(WINE_COLLECTION);

            return await wines.Find("{}").ToListAsync();
        }
    }
}