using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data.Repositories.IRepositories;
using RestaurantApi.Models;

namespace RestaurantApi.Data.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantContext _context;
        public MenuItemRepository(RestaurantContext context)
        {
            _context = context;
        }
        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            var menuItemList = await _context.MenuItems.ToListAsync();
            return menuItemList;
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return null;
            }
            return menuItem;
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }

    }
}
