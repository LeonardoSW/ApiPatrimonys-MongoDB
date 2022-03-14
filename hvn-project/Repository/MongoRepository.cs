using hvn_project.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            _patrimonyDb = _database.GetCollection<PatrimonyItems>(SettingsVariables.Collection);
        }

        public async Task InsertPatrimonyItemAsync(PatrimonyItems item)
        {
            await _patrimonyDb.InsertOneAsync(item);
        }

        public async Task UpdatePatrimonyItemAsync(PatrimonyItems item)
        {
            await _patrimonyDb.ReplaceOneAsync(d => d.PatrimonyNumber == item.PatrimonyNumber, item);
        }

        public async Task DeletePatrimonyItemByIdAsync(string id)
        {
            await _patrimonyDb.DeleteOneAsync(d => d.Id == id);
        }

        public async Task<List<PatrimonyItems>> GetPatrimonyItensListAsync()
        {
            var patrimonyAll = await _patrimonyDb.FindAsync(d => true);

            return patrimonyAll.ToList();
        }

        public async Task<List<PatrimonyItems>> GetPatrimonyItensByFilterAsync(string filter)
        {
            var patrimonyFiltered = await _patrimonyDb.FindAsync(d => d.PatrimonyNumber == filter || d.Description.Contains(filter));

            return patrimonyFiltered.ToList();
        }

        public async Task<List<PatrimonyItems>> GetPatrimonyItemByIdAsync(string id)
        {
            var patrimonyFiltered = await _patrimonyDb.FindAsync(d => d.Id == id);

            return patrimonyFiltered.ToList();
        }
    }
}
