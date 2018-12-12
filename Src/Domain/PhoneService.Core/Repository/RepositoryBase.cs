using Microsoft.EntityFrameworkCore;
using PhoneService.Domain;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly PhoneServiceDbContext context;

        public RepositoryBase(PhoneServiceDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression)
        {
            return await this.context.Set<T>().Where(expression).ToListAsync();
        }

        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }
    }
}
