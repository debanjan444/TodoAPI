using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Common;
using Todo.Application.DTOs.Request;

namespace Todo.Application.Contracts
{
    public interface ITodoService
    {
        Task<Result> CreateTodoAsync(CreateTodoDto todos);
    }
}
