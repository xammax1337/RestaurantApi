using Microsoft.EntityFrameworkCore.Metadata;
using RestaurantApi.Data.Repositories.IRepositories;
using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;
using RestaurantApi.Services.IServices;

namespace RestaurantApi.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<Table> GetAvailableTableAsync(int seatsRequired)
        {
            return await _tableRepository.GetAvailableTableAsync(seatsRequired);
        }

        public async Task UpdateTableAsync(Table table)
        {
            await _tableRepository.UpdateTableAsync(table);
        }

        public async Task AddTableAsync(TableDTO table)
        {
            var newTable = new Table
            {
                TableNumber = table.TableNumber,
                Seats = table.Seats,
                Available = table.Available,
            };
            await _tableRepository.AddTableAsync(newTable);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            await _tableRepository.DeleteTableAsync(tableId);
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            var allTables = await _tableRepository.GetAllTablesAsync();

            return allTables.Select(t => new Table
            {
                TableId = t.TableId,
                TableNumber = t.TableNumber,
                Seats = t.Seats,
                Available = t.Available,
            }).ToList();
        }
    }
}
