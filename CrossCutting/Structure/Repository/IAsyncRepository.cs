using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Structure.Repository
{
    public interface IAsyncRepository<TSource> where TSource : class, IEntity
    {
        Task Add(TSource item);

        Task Update(TSource item);

        Task Remove(long id);

        Task Remove(IEnumerable<long> ids);

        Task<IEnumerable<TSource>> GetRecords();

        Task<IEnumerable<TSource>> GetRecords(Expression<Func<TSource, bool>> predicate);

        Task<TSource> GetRecordById(long id);

        Task<IEnumerable<TSource>> GetRecordsByIds(IEnumerable<long> ids);
    }
}
