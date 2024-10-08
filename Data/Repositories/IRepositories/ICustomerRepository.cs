﻿using RestaurantApi.Models;

namespace RestaurantApi.Data.Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> GetCustomerByEmailAsync(string email);
        Task UpdateCustomerAsync(Customer customer);
    }
}
