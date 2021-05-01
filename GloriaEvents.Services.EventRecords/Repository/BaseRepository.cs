using GloriaEvents.Services.EventRecords.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GloriaEvents.Services.EventComponent.Repository
{
 
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly EventsContext context;
        internal DbSet<T> dbSet;

        public BaseRepository(EventsContext _context)
        {
            this.context = _context;
            this.dbSet = context.Set<T>();
        }
        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AnyAsync(predicate);
        }

        public async Task<T> Find(params object[] keys)
        {
            return await dbSet.FindAsync(keys);
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken)
        {
            try
            {
                return await context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                return 0;
            }

        }
        public int SaveChangessync()
        {
            return context.SaveChanges();
        }



        public async Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.SingleOrDefaultAsync(predicate);
        }


        public async Task Insert(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(T entity)
        {
            try
            {
                dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertBulk(IEnumerable<T> entity)
        {
            try
            {
                await dbSet.AddRangeAsync(entity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();

        }

        public async Task<T> GetFirst()
        {
            return await dbSet.FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            try
            {
                dbSet.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> GetSingleRecord(Expression<Func<T, bool>> predicate)
        {

            return await dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>>
      filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

    }
}
