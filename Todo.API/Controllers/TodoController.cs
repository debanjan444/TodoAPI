using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.API.Extensions;
using Todo.Application.Contracts;
using Todo.Application.DTOs.Request;
using Todo.Application.DTOs.Response;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
   
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;


        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TodoResponseDto> todoList = [];

            todoList.Add(new TodoResponseDto(Name: "sample name 1", Description:"sample description 1",Metadata:null));


            todoList.Add(new TodoResponseDto(Name: "sample name 2", Description: "sample description 2", Metadata: null));
            return Ok(todoList);



        }
        [HttpPost]
        public async Task<IActionResult> Post(
          [FromBody] CreateTodoDto todo)
        {
           
            var result = await _todoService.CreateTodoAsync(todo);
            return result.IsSuccess ? Created() : result.ToProblemDetails();
        }



    }
}
