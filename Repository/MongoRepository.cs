using hvn_project.Models;
using MongoDB.Driver;

namespace hvn_project.Repository
{
    public class MongoRepository : IMongoRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<PatrimonyItems> _patrimonyDb;

        public MongoRepository()
        {
            MongoClient();
        }

        public void MongoClient() 
        {
            _client = new MongoClient(SettingsVariables.Domain);
            _database = _client.GetDatabase(SettingsVariables.DatabaseName);

            _patrimonyDb = _database.GetCollection<PatrimonyItems>("PatrimonyItems");
        }

        public async void InsertAsync(PatrimonyItems item)
        {
            await _patrimonyDb.InsertOneAsync(item);
        }

    }
}
