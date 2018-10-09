using Microsoft.EntityFrameworkCore;
using Structure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Entity.Repository
{
    internal class AsyncRepository<TSource> : IAsyncRepository<TSource>
        where TSource : class, IEntity
    {
        protected DbContext DataBaseContext;
        private DbSet<TSource> dbSet;

        public AsyncRepository(DbContext dataBaseContext)
        {
            DataBaseContext = dataBaseContext;
            dbSet = dataBaseContext.Set<TSource>();
        }

        public async Task Add(TSource item)
        {
            await dbSet.AddAsync(item);
        }

        public async Task<TSource> GetRecordById(long id)
        {
            return await dbSet.SingleAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TSource>> GetRecords()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TSource>> GetRecords(Expression<Func<TSource, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public Task<IEnumerable<TSource>> GetRecordsByIds(IEnumerable<long> ids)
        {
            throw new NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(IEnumerable<long> ids)
        {
            throw new NotImplementedException();
        }

        public Task Update(TSource item)
        {
            throw new NotImplementedException();
        }
    }
}
