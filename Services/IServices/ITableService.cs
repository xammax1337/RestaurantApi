using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;

namespace RestaurantApi.Services.IServices
{
    public interface ITableService
    {
        Task<Table> GetAvailableTableAsync(int seatsRequired);
        Task UpdateTableAsync(Table table);
        Task AddTableAsync(TableDTO table);
        Task DeleteTableAsync(int tableId);
        Task <IEnumerable<Table>>GetAllTablesAsync();
    }
}
