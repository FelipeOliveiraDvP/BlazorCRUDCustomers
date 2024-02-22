using BlazorCRUDCustomers.Domain.Entities;
using BlazorCRUDCustomers.Domain.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorCRUDCustomers.Client.Services
{
    public class CustomerService : ICustomerRepository
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public CustomerService(HttpClient httpClient)
        { 
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            var newCustomer = await _httpClient.PostAsJsonAsync("api/customers", customer);
            
            return await newCustomer.Content.ReadFromJsonAsync<Customer>();
        }

        public async Task<Customer> DeleteAsync(int id)
        {
            var customer = await _httpClient.DeleteAsync($"api/customers/{id}");

            return await customer.Content.ReadFromJsonAsync<Customer>();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customers = await _httpClient.GetAsync("api/customers");

            return await customers.Content.ReadFromJsonAsync<List<Customer>>();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _httpClient.GetAsync($"api/customers/{id}");

            return await customer.Content.ReadFromJsonAsync<Customer>();
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            var newCustomer = await _httpClient.PutAsJsonAsync("api/customers", customer);

            return await newCustomer.Content.ReadFromJsonAsync<Customer>();
        }
    }
}
