using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.DTOs.Response
{
    public record TokenResponseDto(string accessToken, string refreshToken);
}


