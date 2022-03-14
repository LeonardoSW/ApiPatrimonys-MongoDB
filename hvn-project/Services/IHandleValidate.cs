using hvn_project.Models;
using System.Threading.Tasks;

namespace hvn_project.Services
{
    public interface IHandleValidate
    {
        Task<string> validateNewItem(ItemCreate item);
        void validateSearchFilter(string filter);
        Task<string> validateItemToUpdate(ItemUpdate item);
        Task<string> valideItemToDelete(string id);
        bool isValidAlphanymericNumber(string code);
    }
}
