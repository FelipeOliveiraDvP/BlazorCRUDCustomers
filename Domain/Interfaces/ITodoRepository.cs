using BlazorCRUDCustomers.Domain.Entities;

namespace BlazorCRUDCustomers.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);
        Task<Todo> AddAsync(Todo todo);
        Task<Todo> UpdateAsync(Todo todo);
        Task<Todo> DeleteAsync(int id);
    }
}
