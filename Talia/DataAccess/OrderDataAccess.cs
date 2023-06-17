using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Talia.Connection;
using Talia.Helper;
using Talia.Models;
using Talia.Repositories;

namespace Talia.DataAccess
{
    public class OrderDataAccess<T> : IOrder<T> where T : Orders, new()
    {
        public async Task<int> CreateOrderAsync(T newOrder, CancellationToken cancellationToken)
        {
            var _order = newOrder;
            var result = await SqlHelper.Execute(DBUtilities.INSERT_NEW_ORDER, cancellationToken: cancellationToken, _order);
            return result;
        }

        public Task<int> DeleteOrderAsync(int orderId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetOrderAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetOrderByIdAsync(string Id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> UpdateOrderAsync(T editOrder, CancellationToken cancellationToken)
        {
            var _order = new { editOrder.OrderID, editOrder.Status, editOrder.UserID };
            var result = await SqlHelper.Execute(DBUtilities.UPDATE_ORDER_STATUS, cancellationToken: cancellationToken, _order);
            return result;
        }
    }
}
