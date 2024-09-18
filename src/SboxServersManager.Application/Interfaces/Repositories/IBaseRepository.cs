using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> FindAll(bool trackChange);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChange);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
