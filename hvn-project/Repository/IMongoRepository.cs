﻿using hvn_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hvn_project.Repository
{
    public interface IMongoRepository
    {
        void MongoClient();
        Task InsertPatrimonyItemAsync(PatrimonyItems item);
        Task UpdatePatrimonyItemAsync(PatrimonyItems item);
        Task DeletePatrimonyItemByIdAsync(string id);
        Task<List<PatrimonyItems>> GetPatrimonyItensListAsync();
        Task<List<PatrimonyItems>> GetPatrimonyItensByFilterAsync(string filter);
        Task<List<PatrimonyItems>> GetPatrimonyItemByIdAsync(string id);
    }
}
