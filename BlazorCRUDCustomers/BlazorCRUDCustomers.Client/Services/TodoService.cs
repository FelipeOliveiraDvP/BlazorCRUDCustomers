using BlazorCRUDCustomers.Domain.Entities;
using BlazorCRUDCustomers.Domain.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorCRUDCustomers.Client.Services
{
    public class TodoService : ITodoRepository
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<Todo> AddAsync(Todo todo)
        {
            var newTodo = await _httpClient.PostAsJsonAsync("api/todos", todo);

            return await newTodo.Content.ReadFromJsonAsync<Todo>();
        }

        public async Task<Todo> DeleteAsync(int id)
        {
            var todo = await _httpClient.DeleteAsync($"api/todos/{id}");

            return await todo.Content.ReadFromJsonAsync<Todo>();
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            var todos = await _httpClient.GetAsync("api/todos");

            return await todos.Content.ReadFromJsonAsync<List<Todo>>();
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            var todo = await _httpClient.GetAsync($"api/todos/{id}");

            return await todo.Content.ReadFromJsonAsync<Todo>();
        }

        public async Task<Todo> UpdateAsync(Todo todo)
        {
            var newTodo = await _httpClient.PutAsJsonAsync("api/todos", todo);

            return await newTodo.Content.ReadFromJsonAsync<Todo>();
        }
    }
}
