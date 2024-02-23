using BlazorCRUDCustomers.Context;
using BlazorCRUDCustomers.Domain.Entities;
using BlazorCRUDCustomers.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDCustomers.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> AddAsync(Todo todo)
        {
            if (todo == null) return null!;

            var newTodo = _context.Todos.Add(todo).Entity;
            await _context.SaveChangesAsync();

            return newTodo;
        }

        public async Task<Todo> DeleteAsync(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null) return null!;

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null) return null!;

            return todo;
        }

        public async Task<Todo> UpdateAsync(Todo todo)
        {
            if (todo == null) return null!;

            var updateTodo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == todo.Id);

            if (updateTodo == null) return null!;

            updateTodo.Title = todo.Title;
            updateTodo.Status = todo.Status;
            await _context.SaveChangesAsync();

            return todo;
        }
    }
}
