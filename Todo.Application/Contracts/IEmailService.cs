using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendMailAsync(string recipient);
    }
}
