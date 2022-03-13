using hvn_project.Repository;
using System.Threading.Tasks;
using Newtonsoft.Json;
using hvn_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hvn_project.Services
{
    public class HandlerPatrimony : IHandlerPatrimony
    {
        MongoRepository database = new MongoRepository();
        HandleValidate validate = new HandleValidate();
        public HandlerPatrimony()
        {

        }

        public async Task<List<PatrimonyItems>> GetListItemsByFilterAsync(string filter)
        {
            try
            {
                return await database.GetPatrimonyItensByFilterAsync(filter);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<PatrimonyItems>> GetListItemsAsync()
        {
            try
            {
                return await database.GetPatrimonyItensListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> InsertItemAsync(ItemCreate item)
        {
            item.CreateDate = DateTime.UtcNow.AddHours(-3);
            item.UpdateDate = DateTime.UtcNow.AddHours(-3);

            try
            {
                var validateErrors = await validate.validateNewItem(item);

                if (string.IsNullOrEmpty(validateErrors))
                {
                    PatrimonyItems newItem = mapToPatrimonyItem(item);
                    await database.InsertPatrimonyItemAsync(newItem);
                    return null;
                }
            
                return validateErrors;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> UpdateItemAsync(ItemUpdate update)
        {
            try
            {
                var validateErrors = await validate.validateItemToUpdate(update);

                if (string.IsNullOrEmpty(validateErrors))
                {
                    var item = await database.GetPatrimonyItensByFilterAsync(update.PatrimonyNumber);
                    var itemToUpdate = item.FirstOrDefault();
                    itemToUpdate.Status = update.Status;
                    itemToUpdate.UpdateDate = DateTime.UtcNow.AddHours(-3);

                    await database.UpdatePatrimonyItemAsync(itemToUpdate);

                    return null;
                }

                return validateErrors;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> DeleteItemAsync(string itemId)
        {
            try
            {
            var validateErrors = await validate.valideItemToDelete(itemId);

            if (string.IsNullOrEmpty(validateErrors))
            {
                try
                {
                    await database.DeletePatrimonyItemByIdAsync(itemId);
                    return null;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
                return validateErrors;

            }
            catch (Exception e)
            {

                return e.Message;
            }    
        }

        private PatrimonyItems mapToPatrimonyItem(ItemCreate item)
        {
            return new PatrimonyItems()
            {
                Id = null,
                Status = item.Status,
                CreateDate = item.CreateDate,
                UpdateDate = item.UpdateDate,
                Description = item.Description,
                PatrimonyNumber = item.PatrimonyNumber
            };
        }
    }
}
