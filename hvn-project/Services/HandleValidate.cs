using hvn_project.Models;
using hvn_project.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hvn_project.Services
{
    public class HandleValidate : IHandleValidate
    {
        MongoRepository database;
        public HandleValidate()
        {
            database = new MongoRepository();
        }

        public async Task<string> validateNewItem(ItemCreate item)
        {
            var validation = "";

            bool description = string.IsNullOrWhiteSpace(item.Description);
            bool status =  item.Status != PatrimonyStatus.Inactive && item.Status != PatrimonyStatus.Active;
            bool patrimony = string.IsNullOrEmpty(item.PatrimonyNumber);
            bool createDate = string.IsNullOrEmpty(item.CreateDate.ToString());
            bool updateDate = string.IsNullOrEmpty(item.CreateDate.ToString());

            if (description || status || patrimony || createDate || updateDate)
                validation += "Invalid body json;";

            if (!isValidAlphanymericNumber(item.PatrimonyNumber))
                validation += $"The '{item.PatrimonyNumber}' number is not a valid alphanumeric number, ";

            var itemAlreadyExists = await database.GetPatrimonyItensByFilterAsync(item.PatrimonyNumber);

            if(itemAlreadyExists.Count() > 0)
                validation += $"The patrimony number '{item.PatrimonyNumber}' is already exists;";

            return validation;
        }

        public void validateSearchFilter(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                throw new System.InvalidOperationException("The filter value cannot be null.");
        }

        public async Task<string> validateItemToUpdate(ItemUpdate item)
        {
            bool status = item.Status != PatrimonyStatus.Inactive && item.Status != PatrimonyStatus.Active;
            bool patrimony = string.IsNullOrWhiteSpace(item.PatrimonyNumber);

            if (status || patrimony)
                return "Invalid body json;";
            
            var itemAlreadyExists = await database.GetPatrimonyItensByFilterAsync(item.PatrimonyNumber);

            if (itemAlreadyExists.Count() == 0)
                return $"The patrimony number '{item.PatrimonyNumber}' cannot be updated, patrimony not found. Check the list of patrimonys;";

            return null;
        }

        public async Task<string> valideItemToDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return $"The id value to delete cannot be null or empty. Check the list of patrimonys;";

            var foundItem = await database.GetPatrimonyItemByIdAsync(id);

            if (foundItem.Count == 0)
                return $"The id patrimony '{id}' is not found. Check the list of patrimonys;";

            return null;
        }

        public bool isValidAlphanymericNumber(string code)
        {
            if (Regex.IsMatch(code, "^[a-zA-Z0-9]*$") && code.Length == 6)
                return true;

            return false;

        }

    }
}
