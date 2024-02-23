using BlazorCRUDCustomers.Domain.Interfaces;
using BlazorCRUDCustomers.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDtodos.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("todos")]
        public async Task<ActionResult<List<Todo>>> GetAllAsync()
        {
            var todoList = await _repository.GetAllAsync();

            return Ok(todoList);
        }

        [HttpGet("todos/{id}")]
        public async Task<ActionResult<Todo>> GetByIdAsync([FromRoute] int id)
        {
            var todo = await _repository.GetByIdAsync(id);

            return Ok(todo);
        }

        [HttpPost("todos")]
        public async Task<ActionResult<Todo>> AddCustomerAsync(Todo todo)
        {
            var newTodo = await _repository.AddAsync(todo);

            return Ok(newTodo);
        }

        [HttpPut("todos")]
        public async Task<ActionResult<Todo>> UpdateCustomerAsync(Todo todo)
        {
            var updateTodo = await _repository.UpdateAsync(todo);

            return Ok(updateTodo);
        }

        [HttpDelete("todos/{id}")]
        public async Task<ActionResult<Todo>> DeleteCustomerAsync([FromRoute] int id)
        {
            var todo = await _repository.DeleteAsync(id);

            return Ok(todo);
        }
    }
}
