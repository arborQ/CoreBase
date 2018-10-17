using System.Collections.Generic;

namespace Structure.Services
{
    public interface IBaseCoreService<TDto> where TDto : class
    {
        IReadOnlyCollection<TDto> GetElements();

        long Count();
    }
}
