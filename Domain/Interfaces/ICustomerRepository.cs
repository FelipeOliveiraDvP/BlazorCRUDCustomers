using BlazorCRUDCustomers.Domain.Entities;

namespace BlazorCRUDCustomers.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<Customer> DeleteAsync(int id);
    }
}
