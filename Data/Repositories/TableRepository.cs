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

        public async Task<Table> GetAvailableTableAsync(int seatsRequired)
        {
            var availableTables =  await _context.Tables
                .Where(t => t.Seats >= seatsRequired)
                .FirstOrDefaultAsync();
            if (availableTables == null)
            {
                return null;
            }
            return availableTables;
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
            var allTables = await _context.Tables.ToListAsync();
            return allTables;
        }
    }
}
