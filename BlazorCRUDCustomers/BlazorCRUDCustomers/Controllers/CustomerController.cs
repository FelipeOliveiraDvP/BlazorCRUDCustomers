using BlazorCRUDCustomers.Domain.Entities;
using BlazorCRUDCustomers.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDCustomers.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository) 
        {
            _repository = repository;
        }

        [HttpGet("customers")]
        public async Task<ActionResult<List<Customer>>> GetAllAsync() 
        { 
            var customerList = await _repository.GetAllAsync();

            return Ok(customerList);
        }

        [HttpGet("customers/{id}")]
        public async Task<ActionResult<Customer>> GetByIdAsync([FromRoute] int id)
        {
            var customer = await _repository.GetByIdAsync(id);

            return Ok(customer);
        }

        [HttpPost("customers")]
        public async Task<ActionResult<Customer>> AddCustomerAsync(Customer customer)
        {
            var newCustomer = await _repository.AddAsync(customer);

            return Ok(newCustomer);
        }

        [HttpPut("customers")]
        public async Task<ActionResult<Customer>> UpdateCustomerAsync(Customer customer)
        {
            var updateCustomer = await _repository.UpdateAsync(customer);

            return Ok(updateCustomer);
        }

        [HttpDelete("customers/{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomerAsync([FromRoute] int id)
        {
            var customer = await _repository.DeleteAsync(id);

            return Ok(customer);
        }
    }
}
