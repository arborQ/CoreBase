using Microsoft.EntityFrameworkCore;
using Structure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Entity.Repository
{
    internal class Repository<TSource> : IRepository<TSource>
        where TSource : class, IEntity
    {
        protected DbContext DataBaseContext;
        private DbSet<TSource> dbSet;

        public Repository(DbContext dataBaseContext)
        {
            DataBaseContext = dataBaseContext;
            dbSet = dataBaseContext.Set<TSource>();
        }

        public void Add(TSource item)
        {
            dbSet.Add(item);
        }

        public TSource GetRecordById(long id)
        {
            return dbSet.Single(e => e.Id == id);
        }

        public IQueryable<TSource> GetRecords()
        {
            return dbSet.AsQueryable();
        }

        public IQueryable<TSource> GetRecords(Expression<Func<TSource, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IQueryable<TSource> GetRecordsByIds(IEnumerable<long> ids)
        {
            return GetRecords(e => ids.Contains(e.Id));
        }

        public void Remove(long id)
        {
            var record = GetRecordById(id);

            dbSet.Remove(record);
        }

        public void Remove(IEnumerable<long> ids)
        {
            var records = GetRecordsByIds(ids);

            dbSet.RemoveRange(records);
        }

        public void Update(TSource item)
        {
            DataBaseContext.Entry(item).State = EntityState.Modified;
        }
    }
}
