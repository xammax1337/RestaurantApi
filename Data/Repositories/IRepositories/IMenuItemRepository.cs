using RestaurantApi.Models;

namespace RestaurantApi.Data.Repositories.IRepositories
{
    public interface IMenuItemRepository
    {
        Task AddMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(int id);
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemByIdAsync(int id);
        Task UpdateMenuItemAsync(MenuItem menuItem);
        //Task AddMenuItemToMenuAsync(int menuItemId, int menuId);
    }
}
