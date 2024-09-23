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

        public async Task<Table> GetAvailableTableAsync(int seatsRequired, DateTime bookingTime)
        {
            return await _tableRepository.GetAvailableTableAsync(seatsRequired, bookingTime);
        }

        public async Task UpdateTableAsync(int id, TableDTO updatedTable)
        {
            var table = await _tableRepository.GetTableByIdAsync(id);

            table.TableNumber = updatedTable.TableNumber;
            table.Seats = updatedTable.Seats;
            table.Available = updatedTable.Available;

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

        public async Task<IEnumerable<ViewTableDTO>> GetAllTablesAsync()
        {
            var allTables = await _tableRepository.GetAllTablesAsync();

            return allTables.Select(t => new ViewTableDTO
            {
                TableId = t.TableId,
                TableNumber = t.TableNumber,
                Seats = t.Seats,
                Available = t.Available,
                Bookings = t.Bookings.Select(b => new ViewTableBookingDTO
                {
                    Id = b.Id,
                    TimeBooked = b.TimeBooked,
                    CustomerCount = b.CustomerCount
                }).ToList()
            }).ToList();
        }

        public async Task<TableDTO> GetTableByIdAsync(int id)
        {
            var table = await _tableRepository.GetTableByIdAsync(id);
            if (table == null)
            {
                return null;
            }

            return new TableDTO
            {
                TableNumber = table.TableNumber,
                Seats = table.Seats,
                Available = table.Available
            };
        }
    }
}
