using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;

namespace RestaurantApi.Data.Repositories.IRepositories
{
    public interface ITableRepository
    {
        Task<Table> GetAvailableTableAsync(int seatsRequired, DateTime bookingTime);
        Task UpdateTableAsync(Table table);
        Task AddTableAsync(Table table);
        Task DeleteTableAsync(int tableId);
        Task <IEnumerable<Table>> GetAllTablesAsync();
        Task<Table> GetTableByIdAsync(int id);
    }
}
