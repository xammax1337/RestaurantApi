using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;

namespace RestaurantApi.Services.IServices
{
    public interface IMenuItemService
    {
        Task AddMenuItemAsync(MenuItemDTO menuItem);
        Task DeleteMenuItemAsync(int id);
        Task<IEnumerable<MenuItemDTO>> GetAllMenuItemsAsync();
        Task<MenuItemDTO> GetMenuItemByIdAsync(int id);
        Task UpdateMenuItemAsync(int id, MenuItemDTO updatedMenuItem);
    }
}
