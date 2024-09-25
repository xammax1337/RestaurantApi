using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models.DTOs;
using RestaurantApi.Services.IServices;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Route("AddCustomer")]
        [HttpPost]
        public async Task<ActionResult> AddCustomer(CustomerDTO customer)
        {
            await _customerService.AddCustomerAsync(customer);
            return Ok();
        }

        [Route("DeleteCustomer/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok();
        }

        [Route("GetAllCustomers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            var customerList = await _customerService.GetAllCustomersAsync();
            return Ok(customerList);
        }

        [Route("GetCustomerById/{id}")]
        [HttpGet]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id) 
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            return Ok(customer);
        }

        [Route("UpdateCustomer/{id}")]
        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(int id, CustomerDTO updatedCustomer)
        {
            await _customerService.UpdateCustomerAsync(id, updatedCustomer);
            return Ok();
        }
    }
}
