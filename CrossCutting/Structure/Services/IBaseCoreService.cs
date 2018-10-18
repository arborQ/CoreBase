﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Structure.Services
{
    public interface IBaseCoreService<TDto> where TDto : class
    {
        IReadOnlyCollection<TDto> GetElements();

        TDto AddElement(TDto contract);

        Task RemoveAsync(IReadOnlyCollection<long> ids);

        void Remove(IReadOnlyCollection<long> ids);

        long Count();
    }
}
