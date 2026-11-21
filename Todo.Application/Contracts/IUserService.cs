using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.DTOs.Request;

namespace Todo.Application.Contracts
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserDto userDto);
    }
}
