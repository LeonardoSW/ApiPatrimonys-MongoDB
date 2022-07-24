using hvn_project.Configuration.Usuario;
using hvn_project.Models;
using hvn_project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace hvn_project.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PatrimonyController : ControllerBase
    {
        HandlerPatrimony handlerPatrimony;

        public PatrimonyController()
        {
            handlerPatrimony = new HandlerPatrimony();
        }

        [AllowAnonymous]
        [HttpGet("/ping")]
        public IActionResult TestConnection()
        {
            return Ok("pong!!!");
        }

        [HttpGet("/patrimony/{filter}")]
        public async Task<IActionResult> GetItemsListByFilter([FromRoute] string filter)
        {
            try
            {
                var GetListByFilterResponse = await handlerPatrimony.GetListItemsByFilterAsync(filter);
                return Ok(GetListByFilterResponse);
            }
            catch (Exception e)
            {
                return BadRequest(Content(e.Message));
            }
        }
        [HttpGet("/patrimony")]
        public async Task<IActionResult> GetItemsList()
        {
            try
            {
                var GetListResponse = await handlerPatrimony.GetListItemsAsync();
                return Ok(GetListResponse);
            }
            catch (Exception e)
            {
                return BadRequest(Content(e.Message));
            }

        }

        [HttpPost("/patrimony")]
        public async Task<IActionResult> InsertPatrimony([FromBody] ItemCreate item)
        {
            var insertRespose = await handlerPatrimony.InsertItemAsync(item);

            if (string.IsNullOrEmpty(insertRespose))
                return Ok(Content($"Patrimony {item.PatrimonyNumber} created with success!"));

            else
                return BadRequest(Content($"{insertRespose}"));
        }

        [HttpPut("/patrimony")]
        public async Task<IActionResult> UpdatePatrimony([FromBody] ItemUpdate itemToUpdate)
        {
            var updateResponse = await handlerPatrimony.UpdateItemAsync(itemToUpdate);

            if (string.IsNullOrEmpty(updateResponse))
                return Ok(Content($"Patrimony '{itemToUpdate.PatrimonyNumber}' updated with success!"));

            else
                return BadRequest(Content($"{updateResponse}"));
        }

        [HttpDelete("/patrimony/{database_id}")]
        public async Task<IActionResult> DeletePatrimony([FromRoute] string database_id)
        {
            var deleteResponse = await handlerPatrimony.DeleteItemAsync(database_id);

            if (string.IsNullOrEmpty(deleteResponse))
                return Ok(Content($"Id '{database_id}' removed with success!"));

            else
                return BadRequest(Content($"{deleteResponse}"));
        }
    }
}
