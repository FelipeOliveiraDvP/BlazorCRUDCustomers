using BlazorCRUDCustomers.Client.Services;
using BlazorCRUDCustomers.Domain.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<ICustomerRepository, CustomerService>();
builder.Services.AddScoped<ITodoRepository, TodoService>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

await builder.Build().RunAsync();
