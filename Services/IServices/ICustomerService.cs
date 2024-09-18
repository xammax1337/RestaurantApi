using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;

namespace RestaurantApi.Services.IServices
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(CustomerDTO customer);
        Task DeleteCustomerAsync(int id);
        Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task<CustomerDTO> GetCustomerByEmailAsync(string email);
        Task UpdateCustomerAsync(CustomerDTO customer);
    }
}
