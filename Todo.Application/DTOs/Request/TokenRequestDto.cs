using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.DTOs.Request;
public record TokenRequestDto(string userName, string password);
