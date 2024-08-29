using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;

namespace RestaurantApi.Services.IServices
{
    public interface IMenuItemService
    {
        Task AddMenuItemAsync(MenuItemDTO menuItem);
        Task DeleteMenuItemAsync(int id);
        Task<IEnumerable<MenuItemDTO>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemByIdAsync(int id);
        Task UpdateMenuItemAsync(MenuItemDTO menuItem);
    }
}
