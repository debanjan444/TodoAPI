using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Contracts
{
    public interface ITokenRevocationService
    {
        Task<bool> IsSessionRevokedAsync(Guid sessionId);
        Task InvalidateSessionCacheAsync(Guid sessionId);

    }
}
