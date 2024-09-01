using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;
using RestaurantApi.Services;
using RestaurantApi.Services.IServices;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        public MenuController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;  
        }

        [Route("AddMenuItem")]
        [HttpPost]
        public async Task<ActionResult> AddMenuItem(MenuItemDTO menuItem)
        {
            await _menuItemService.AddMenuItemAsync(menuItem);
            return Ok();
        }        
        
        [Route("DeleteMenuItem")]
        [HttpPost]
        public async Task<ActionResult> DeleteMenuItem(int id)
        {
            await _menuItemService.DeleteMenuItemAsync(id);
            return Ok();
        }

        [Route("GetAllMenuItems")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetAllMenuItems()
        {
            var menuItemList = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(menuItemList);
        }

        [Route("GetMenuItemById")]
        [HttpGet]
        public async Task<ActionResult<MenuItem>> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
            return Ok(menuItem);
        }

        [Route("UpdateMenuItem")]
        [HttpPost]
        public async Task<ActionResult> UpdateMenuItem(int id, MenuItemDTO updatedMenuItem)
        {
            await _menuItemService.UpdateMenuItemAsync(id, updatedMenuItem);
            return Ok();
        }
    }
}
