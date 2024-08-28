using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;
using RestaurantApi.Services.IServices;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [Route("AddTable")]
        [HttpPost]
        public async Task<ActionResult> AddTable(Table table)
        {
            await _tableService.AddTableAsync(table);
            return Ok();
        }

        [Route("DeleteTable")]
        [HttpPost]
        public async Task<ActionResult> DeleteTable(int tableId)
        {
            await _tableService.DeleteTableAsync(tableId);
            return Ok();
        }

        [Route("UpdateTable")]
        [HttpPost]
        public async Task<ActionResult> UpdateTable(int tableId)
        {
            await _tableService.UpdateTableAsync(tableId);
            return Ok();
        }
    }
}
