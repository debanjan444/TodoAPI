using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.DomainEntities;

namespace Todo.Application.Contracts
{
    public interface IRefreshTokenService
    {
        Task<RefreshTokenDomain> GetRefreshTokenById(Guid id);
    }
}
