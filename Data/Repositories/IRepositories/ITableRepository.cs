using RestaurantApi.Models;

namespace RestaurantApi.Data.Repositories.IRepositories
{
    public interface ITableRepository
    {
        Task<Table> GetAvailableTableAsync(int seatsRequired);
        Task UpdateTableAsync(Table table);
        Task AddTableAsync(Table table);
        Task DeleteTableAsync(int tableId);
    }
}
