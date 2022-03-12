using hvn_project.Models;

namespace hvn_project.Repository
{
    public interface IMongoRepository
    {
        void MongoClient();
        void InsertAsync(PatrimonyItems item);

    }
}
