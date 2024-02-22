using BlazorCRUDCustomers.Context;
using BlazorCRUDCustomers.Domain.Entities;
using BlazorCRUDCustomers.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDCustomers.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            if (customer == null) return null!;

            var newCustomer = _context.Customers.Add(customer).Entity;
            await _context.SaveChangesAsync();

            return newCustomer;
        }

        public async Task<Customer> DeleteAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null) return null!;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;            
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null) return null!;

            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            if (customer == null) return null!;

            var updateCustomer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);

            if (updateCustomer == null) return null!;

            updateCustomer.Name = customer.Name;
            updateCustomer.Email = customer.Email;
            await _context.SaveChangesAsync();

            return customer;
        }
    }
}
