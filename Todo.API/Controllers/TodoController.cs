using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs.Response;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
   
    public class TodoController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TodoResponseDto> todoList = [];

            todoList.Add(new TodoResponseDto(Name: "sample name 1", Description:"sample description 1",Metadata:null));


            todoList.Add(new TodoResponseDto(Name: "sample name 2", Description: "sample description 2", Metadata: null));
            return Ok(todoList);



        }
    }
}
