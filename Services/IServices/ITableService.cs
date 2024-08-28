using RestaurantApi.Models;

namespace RestaurantApi.Services.IServices
{
    public interface ITableService
    {
        Task<Table> GetAvailableTableAsync(int seatsRequired);
        Task UpdateTableAsync(int tableId);
        Task AddTableAsync(Table table);
        Task DeleteTableAsync(int tableId);
    }
}
