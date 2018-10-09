﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Structure.Repository
{
    public interface IRepository<TSource>
        where TSource : class, IEntity
    {
        void Add(TSource item);

        void Update(TSource item);

        void Remove(long id);

        void Remove(IEnumerable<long> ids);

        IQueryable<TSource> GetRecords();

        IQueryable<TSource> GetRecords(Expression<Func<TSource, bool>> predicate);

        TSource GetRecordById(long id);

        IQueryable<TSource> GetRecordsByIds(IEnumerable<long> ids);
    }
}