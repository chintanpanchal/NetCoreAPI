using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Talia.Repositories
{
    public interface IStoreManager<TStore> : IDisposable where TStore : class
    {
        Task<IEnumerable<TStore>> GetStoreAsync(CancellationToken cancellationToken);
        Task<int> DeleteStoreAsync(int storeId, CancellationToken cancellationToken);
        Task<int> CreateStoreAsync(TStore newStore, CancellationToken cancellationToken);
        Task<int> UpdateStoreAsync(TStore editStore, CancellationToken cancellationToken);
        Task<TStore> GetStoreByIdAsync(string Id, CancellationToken cancellationToken);
    }
}
