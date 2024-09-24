using Microsoft.AspNetCore.Identity;
using RestaurantApi.Models.DTOs;

namespace RestaurantApi.Services.IServices
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);
        Task RegisterAsync(string email, string password, string role);
        Task<bool> IsUserInRoleAsync(string email, string role);
    }
}
