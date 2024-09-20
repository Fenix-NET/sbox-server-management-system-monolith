using Microsoft.EntityFrameworkCore;
using SboxServersManager.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ServersManagerDbContext ServersManagerDbContext;
        public BaseRepository(ServersManagerDbContext dbContext) 
        {
            ServersManagerDbContext = dbContext;
        }

        public IQueryable<T> FindAll(bool trackChange)
        {
            return !trackChange ?
                ServersManagerDbContext.Set<T>().AsNoTracking() :
                ServersManagerDbContext.Set<T>();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChange)
        {
            return !trackChange ?
                ServersManagerDbContext.Set<T>().AsNoTracking().Where(expression) :
                ServersManagerDbContext.Set<T>().Where(expression);
        }
        public async Task Create(T entity) 
        {
            await ServersManagerDbContext.Set<T>().AddAsync(entity);
        }
        public void Update(T entity) 
        {
            ServersManagerDbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            ServersManagerDbContext.Set<T>().Remove(entity);
        }
    }
}
