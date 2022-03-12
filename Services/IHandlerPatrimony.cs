using hvn_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hvn_project.Services
{
    public interface IHandlerPatrimony
    {
        Task<List<PatrimonyItems>> GetListItemsByFilterAsync(string filter);
        Task<List<PatrimonyItems>> GetListItemsAsync();
        Task<string> InsertItemAsync(PatrimonyItems item);
        Task<string> UpdateItemAsync(ItemUpdate update);
        Task<string> DeleteItemAsync(string itemId);
    }
}
