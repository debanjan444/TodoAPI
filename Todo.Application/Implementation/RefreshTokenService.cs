using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts;
using Todo.Domain.DomainEntities;
using Todo.Domain.RepositoryInterface;

namespace Todo.Application.Implementation
{
    public class RefreshTokenService(IRefreshTokenRepository _refreshTokenRepository) :IRefreshTokenService
    {
        public async Task<RefreshTokenDomain> GetRefreshTokenById(Guid id)
        {
            return await _refreshTokenRepository.GetRefreshTokenById(id);
        }
    }
}
