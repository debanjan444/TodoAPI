using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.DomainEntities;

namespace Todo.Domain.RepositoryInterface
{
    public interface ITodoRepository : IGenericRepository<TodoListDomain>
    {
        Task<List<TodoListDomain>> GetTodosAsync(Guid userId);
    }
}
