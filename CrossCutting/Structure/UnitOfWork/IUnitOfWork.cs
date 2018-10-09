using System;
using System.Threading.Tasks;

namespace Structure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        Task CommitAsync();
    }
}
