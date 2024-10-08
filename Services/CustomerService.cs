﻿using RestaurantApi.Data.Repositories.IRepositories;
using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;
using RestaurantApi.Services.IServices;

namespace RestaurantApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task AddCustomerAsync(CustomerDTO customer)
        {
            var newCustomer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
            };
            await _customerRepo.AddCustomerAsync(newCustomer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepo.DeleteCustomerAsync(id);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            var customerList = await _customerRepo.GetAllCustomersAsync();
            return customerList.Select(c => new CustomerDTO
            {
                CustomerId = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                //Bookings = c.Bookings
            }).ToList();
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepo.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return null;
            }

            return new CustomerDTO 
            { 
                FirstName = customer.FirstName, 
                LastName = customer.LastName, 
                Email = customer.Email, 
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task<CustomerDTO> GetCustomerByEmailAsync(string email)
        {
            var customer = await _customerRepo.GetCustomerByEmailAsync(email);

            if (customer == null)
            {
                return null;
            }

            return new CustomerDTO
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task UpdateCustomerAsync(int id, CustomerDTO updatedCustomer)
        {
            var customer = await _customerRepo.GetCustomerByIdAsync(id);
            
            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.Email = updatedCustomer.Email;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;

            await _customerRepo.UpdateCustomerAsync(customer);
        }
    }
}
