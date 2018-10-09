using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Structure.Repository;
using Structure.UnitOfWork;

namespace Data.Entity.Repository
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected DbContext DataBaseContext;

        protected UnitOfWork(DbContext dataBaseContext)
        {
            DataBaseContext = dataBaseContext;
        }

        protected IRepository<TEntity> CreateRepository<TEntity>()
            where TEntity : class, IEntity
        {
            return new Repository<TEntity>(DataBaseContext);
        }

        protected IAsyncRepository<TEntity> CreateAsyncRepository<TEntity>()
            where TEntity : class, IEntity
        {
            return new AsyncRepository<TEntity>(DataBaseContext);
        }

        public void Commit()
        {
            DataBaseContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await DataBaseContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (DataBaseContext != null)
            {
                DataBaseContext.Dispose();
            }
        }
    }
}
