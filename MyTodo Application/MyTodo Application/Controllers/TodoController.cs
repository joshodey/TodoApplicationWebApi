using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTodo_Application.DTO;
using MyTodo_Application.Helper;
using MyTodo_Application.Services;

namespace MyTodo_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodo _todo;

        public TodoController(ITodo todo)
        {
            _todo = todo;
        }

        [HttpPost("Add")]
        public IActionResult AddTodo([FromBody] MyTodoDto todo)
        {
            if (todo == null)
            {
                return BadRequest("Invalid details submitted");
            }
            _todo.AddTodo(todo);
            return Ok("Todo items added successfully");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> RemoveTodo([FromBody] string taskId)
        {
            var remove = _todo.DeleteTodo(taskId);

            if (remove == null)
            {
                return BadRequest("Todo list not found");
            }
            return Ok("Todo List Item Deleted Successfully");
        }

        [HttpPut("Update")]
        public IActionResult UpdateTodo(MyTodoDto todo)
        {
            _todo.UpdateTodo(todo);
            return Ok("Updated Successfully");
        }

        [HttpGet("RetrieveAll")]
        public async Task<IActionResult> GetAllTodo([FromQuery] PaginationParameters parameters)
        {
            var todo = await _todo.GetTodo(parameters);
            if (todo == null)
                return BadRequest("Your Todo List is empty");
            return Ok(todo);
        }

        [HttpGet("SearchById")]
        public IActionResult SearchById (string taskId)
        {
            var todo = _todo.GetTodoByTaskId(taskId);
            if (todo == null)
                return BadRequest("Todo not found");
            return Ok(todo);
        }

        [HttpGet("SearchByTaskStatus")]
        public async Task<IActionResult> SearchByTaskStatus([FromQuery] string taskstatus)
        {
            var todo = await _todo.GetTodoByTaskStatus(taskstatus);
            if (todo == null)
                return BadRequest("Todo not found");
            return Ok(todo);
        }

        [HttpGet("SearchByTaskName")]
        public async Task<IActionResult> SearchByTaskName([FromQuery] string taskname)
        {
            var todo = await _todo.GetTodoByTaskName(taskname);
            if (todo == null)
                return BadRequest("Todo not found");
            return Ok(todo);
        }
    }
}
