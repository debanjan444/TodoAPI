using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Common;
using Todo.Application.Contracts;
using Todo.Application.DTOs.Request;
using Todo.Application.Mappers;
using Todo.Domain.RepositoryInterface;

namespace Todo.Application.Implementation
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ICurrentUserService _currentUserService;


        public TodoService(
     ITodoRepository todoRepository,
     ICurrentUserService currentUserService)
        {
            _todoRepository = todoRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result> CreateTodoAsync(CreateTodoDto todos)
        {
            var todo
            = todos.ConvertToTodoListDomain();

            todo.UserId = Guid.Parse(_currentUserService.GetCurrentUserId());

            await _todoRepository.AddAsync(todo);

            int rowsInserted = await _todoRepository.CommitAsync();

            return rowsInserted > 0
               ? Result.Success()
               : Result.Failure(Error.Failure("Todo.CreateFailed", "Could not create the todo item."));
        }
    }
}
