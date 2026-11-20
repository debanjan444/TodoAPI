using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.RepositoryInterface
{
    public interface IGenericRepository<TDomain> where TDomain : class
    {
        Task<TDomain> GetByIdAsync(object id);

        Task<IEnumerable<TDomain>> GetAllAsync();


        Task  AddAsync(TDomain entity);


        Task<int> CommitAsync();
    }
}
