using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.RepositoryInterface;
using Todo.Infrastructure.Persistence.Entities;

namespace Todo.Infrastructure.Repository
{
    public class GenericRepository<TDomain, TEntity> : IGenericRepository<TDomain> where TDomain : class where TEntity : class
    {
        protected readonly TodoAppDbContext _todoAppDbContext;
        protected readonly IMapper _mapper;
        public GenericRepository(TodoAppDbContext todoAppDbContext, IMapper mapper)
        {
            _todoAppDbContext = todoAppDbContext;
            _mapper = mapper;
        }
        public async Task AddAsync(TDomain domain)
        { 
             var entityToAdd = _mapper.Map<TEntity>(domain);
            await _todoAppDbContext.Set<TEntity>().AddAsync(entityToAdd);
        }

        public async Task<int> CommitAsync()
        {
           return await  _todoAppDbContext.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            return await _todoAppDbContext.Set<TEntity>()
                .ProjectTo<TDomain>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<TDomain?> GetByIdAsync(object id)
        {
           var entity = await  _todoAppDbContext.Set<TEntity>().FindAsync(id);



            return entity ==  null ? null : _mapper.Map<TDomain>(entity);

        }
        public async Task DetachAsync(object entityId)
        {
            var entity = _todoAppDbContext.Set<TEntity>().Find(entityId);
            if (entity != null)
            {
                _todoAppDbContext.Entry(entity).State = EntityState.Detached;
            }
            await Task.CompletedTask;
        }


        public async Task UpdateAsync(TDomain domain)
        {
            var entity = _mapper.Map<TEntity>(domain); // domain --> entity

            _todoAppDbContext.Set<TEntity>().Update(entity);
        }

    }
}
