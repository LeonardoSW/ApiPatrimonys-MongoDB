using hvn_project.Models;
using hvn_project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace hvn_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatrimonyController : ControllerBase
    {
        private readonly ILogger<PatrimonyController> _logger;
        HandlerPatrimony handlerPatrimony;

        public PatrimonyController(ILogger<PatrimonyController> logger)
        {
            _logger = logger;
            handlerPatrimony = new HandlerPatrimony();
        }

        [HttpGet("/patrimony/items/{filter}")]
        public async Task<IActionResult> GetItemsListByFilter([FromRoute] string filter)
        {
            try
            {
                var GetListByFilterResponse = await handlerPatrimony.GetListItemsByFilterAsync(filter);
                return Ok(GetListByFilterResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/patrimony/items/list")]
        public async Task<IActionResult> GetItemsList()
        {
            try
            {
                var GetListResponse = await handlerPatrimony.GetListItemsAsync();
                return Ok(GetListResponse);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("/patrimony/create")]
        public async Task<IActionResult> InsertPatrimony([FromBody] ItemCreate item)
        {
            var insertRespose = await handlerPatrimony.InsertItemAsync(item);
            
            if (string.IsNullOrEmpty(insertRespose)) 
                return Ok(Content($"Patrimony {item.PatrimonyNumber} created with success!"));

            else 
                return BadRequest(Content($"{insertRespose}"));
        }

        [HttpPut("/patrimony/update")]
        public async Task<IActionResult> UpdatePatrimony([FromBody] ItemUpdate itemToUpdate)
        {
            var updateResponse = await handlerPatrimony.UpdateItemAsync(itemToUpdate);
            
            if (string.IsNullOrEmpty(updateResponse))
                return Ok(Content($"Patrimony '{itemToUpdate.PatrimonyNumber}' updated with success!"));

            else
                return BadRequest(Content($"{updateResponse}"));
        }

        [HttpDelete("/patrimony/remove/{database_id}")]
        public async Task<IActionResult> DeletePatrimony([FromRoute] string database_id)
        {
            var deleteResponse = await handlerPatrimony.DeleteItemAsync(database_id);

            if(string.IsNullOrEmpty(deleteResponse))
                return Ok(Content($"Id '{database_id}' deleted with success!"));

            else
                return BadRequest(Content($"{deleteResponse}"));
        }
    }
}
