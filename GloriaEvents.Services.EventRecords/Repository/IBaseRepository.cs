using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GloriaEvents.Services.EventComponent.Repository
{
    public interface IBaseRepository<T> where T : class
    {

        Task<bool> Any(Expression<Func<T, bool>> predicate = null);

        Task<T> Find(params object[] keys);

        Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate);

        Task<int> SaveChanges(CancellationToken cancellationToken = default);
        int SaveChangessync();

        Task InsertBulk(IEnumerable<T> entity);

        Task Insert(T entity);

        void Update(T entity);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
     string includeProperties = "");
        Task<IEnumerable<T>> GetAll();
        Task<T> GetFirst();
        Task<T> GetById(Object id);

        Task Delete(T entity);

        Task<T> GetSingleRecord(Expression<Func<T, bool>> predicate);

    }
}
