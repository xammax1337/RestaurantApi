using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;

namespace RestaurantApi.Services.IServices
{
    public interface ITableService
    {
        Task<Table> GetAvailableTableAsync(int seatsRequired, DateTime bookingTime);
        Task UpdateTableAsync(int id, TableDTO updatedTable);
        Task AddTableAsync(TableDTO table);
        Task DeleteTableAsync(int tableId);
        Task <IEnumerable<ViewTableDTO>>GetAllTablesAsync();
        Task<TableDTO> GetTableByIdAsync(int id);
    }
}
