using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data.Repositories.IRepositories;
using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;

namespace RestaurantApi.Data.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantContext _context;
        public TableRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<Table> GetAvailableTableAsync(int seatsRequired, DateTime bookingTime)
        {
            // Fetch tables with enough seats and are available
            var availableTables = await _context.Tables
                .Where(t => t.Seats >= seatsRequired)
                .ToListAsync(); // Load into memory

            // Fetch bookings within the next 2 hours
            var conflictingBookings = await _context.Bookings
                .Where(b => b.TimeBooked > bookingTime.AddHours(-2) && b.TimeBooked < bookingTime.AddHours(2))
                .ToListAsync(); // Load into memory

            // Find an available table that doesn't have a conflict
            var availableTable = availableTables
                .FirstOrDefault(table =>
                    !conflictingBookings.Any(booking =>
                        booking.TableId == table.TableId));

            return availableTable;
        }

        public async Task UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        } 

        public async Task AddTableAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var deleteTable = await _context.Tables.FindAsync(tableId);
            if (deleteTable != null)
            {
                _context.Tables.Remove(deleteTable);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            var allTables = await _context.Tables
                .Include(t => t.Bookings)
                .ToListAsync();
            return allTables;
        }

        public async Task<Table> GetTableByIdAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return null;
            }
            return table;
        }
    }
}
