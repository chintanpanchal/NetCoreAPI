using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Talia.Repositories
{
    public interface IOrder<TOrder> where TOrder : class
    {
        Task<IEnumerable<TOrder>> GetOrderAsync(CancellationToken cancellationToken);
        Task<int> DeleteOrderAsync(int orderId, CancellationToken cancellationToken);
        Task<int> CreateOrderAsync(TOrder newOrder, CancellationToken cancellationToken);
        Task<int> UpdateOrderAsync(TOrder editOrder, CancellationToken cancellationToken);
        Task<TOrder> GetOrderByIdAsync(string Id, CancellationToken cancellationToken);
    }
}
