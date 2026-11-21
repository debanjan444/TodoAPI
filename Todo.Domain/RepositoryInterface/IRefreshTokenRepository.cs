using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.DomainEntities;

namespace Todo.Domain.RepositoryInterface
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshTokenDomain>

    {
        Task<RefreshTokenDomain?> GetByRefreshTokenAsync(string tokenHash);

        Task<IEnumerable<RefreshTokenDomain>> GetActiveTokensByUserIdAsync(Guid userId);

        Task<RefreshTokenDomain?> GetByIdWithDetailsAsync(Guid id);

        Task<int> RevokeAllUserTokensAsync(Guid userId, string? revokedByIp = null);

        Task<int> DeleteExpiredTokensAsync();

        Task<RefreshTokenDomain?> GetRevokedTokenAsync(Guid id);

        Task<RefreshTokenDomain> GetRefreshTokenById(Guid id);



    }
}
