using hvn_project.Models;
using hvn_project.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hvn_project.Services
{
    public interface IHandlerPatrimony
    {
        Task<ResultBaseOutputModel<List<PatrimonyItems>>> GetListItemsByFilterAsync(string filter);
        Task<ResultBaseOutputModel<List<PatrimonyItems>>> GetListItemsAsync();
        Task<string> InsertItemAsync(ItemCreate item);
        Task<string> UpdateItemAsync(ItemUpdate update);
        Task<string> DeleteItemAsync(string itemId);
    }
}
