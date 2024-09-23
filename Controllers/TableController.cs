using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;
using RestaurantApi.Services;
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
        public async Task<ActionResult> AddTable(TableDTO table)
        {
            await _tableService.AddTableAsync(table);
            return Ok();
        }

        [Route("DeleteTable/{tableId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteTable(int tableId)
        {
            await _tableService.DeleteTableAsync(tableId);
            return Ok();
        }

        [Route("GetAllTables")]
        [HttpGet]
        public async Task<ActionResult> GetAllTables()
        {
            var allTables = await _tableService.GetAllTablesAsync();
            return Ok(allTables);
        }

        [Route("UpdateTable/{id}")]
        [HttpPut]
        public async Task<ActionResult> UpdateTable(int id, TableDTO updatedTable)
        {
            await _tableService.UpdateTableAsync(id, updatedTable);
            return Ok();
        }
    }
}
