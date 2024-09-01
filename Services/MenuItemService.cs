using RestaurantApi.Data.Repositories.IRepositories;
using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;
using RestaurantApi.Services.IServices;

namespace RestaurantApi.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepo;
        public MenuItemService(IMenuItemRepository menuItemRepo)
        {
            _menuItemRepo = menuItemRepo;
        }
        public async Task AddMenuItemAsync(MenuItemDTO menuItem)
        {
            var newMenuItem = new MenuItem
            {
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                Available = menuItem.Available,
            };
            await _menuItemRepo.AddMenuItemAsync(newMenuItem);
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            await _menuItemRepo.DeleteMenuItemAsync(id);
        }

        public async Task<IEnumerable<MenuItemDTO>> GetAllMenuItemsAsync()
        {
            var menuItemList = await _menuItemRepo.GetAllMenuItemsAsync();
            return menuItemList.Select(m => new MenuItemDTO
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                Available = m.Available,
            }).ToList();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int id)
        {
            var menuItem = await _menuItemRepo.GetMenuItemByIdAsync(id);
            if (menuItem == null)
            {
                return null;
            }

            return new MenuItem
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                Available = menuItem.Available,
                Menus = menuItem.Menus,
            };
        }

        public async Task UpdateMenuItemAsync(int id, MenuItemDTO updatedMenuItem)
        {
            var menuItem = await _menuItemRepo.GetMenuItemByIdAsync(id);
            
            menuItem.Name = updatedMenuItem.Name;
            menuItem.Description = updatedMenuItem.Description;
            menuItem.Price = updatedMenuItem.Price;
            menuItem.Available = updatedMenuItem.Available;

            await _menuItemRepo.UpdateMenuItemAsync(menuItem);
        }
    }
}
