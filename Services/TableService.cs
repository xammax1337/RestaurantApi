using Microsoft.EntityFrameworkCore.Metadata;
using RestaurantApi.Data.Repositories.IRepositories;
using RestaurantApi.Models;
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

        public async Task AddTableAsync(Table table)
        {
            await _tableRepository.AddTableAsync(table);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            await _tableRepository.DeleteTableAsync(tableId);
        }
    }
}
