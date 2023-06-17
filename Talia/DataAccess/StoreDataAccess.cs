using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Talia.Connection;
using Talia.Helper;
using Talia.Models;
using Talia.Repositories;

namespace Talia.DataAccess
{
    public class StoreDataAccess<T> : IStoreManager<T> where T : StoreDetails, new()
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
        public async Task<int> DeleteStoreAsync(int id, CancellationToken cancellationToken)
        {
            var param = new { StoreId = id };
            return await SqlHelper.Execute(DBUtilities.DELETE_STORE_LIST, cancellationToken, param);
        }
        public async Task<IEnumerable<T>> GetStoreAsync(CancellationToken cancellationToken)
        {
            List<T> recordList = (await SqlHelper.GetRecords<T>(DBUtilities.GET_STORE_LIST)).ToList();
            return recordList;
        }
        public async Task<T> GetStoreByIdAsync(string Id, CancellationToken cancellationToken)
        {
            var _param = new { StoreId = Id };
            T recordList = await SqlHelper.GetRecord<T>(DBUtilities.GET_STORE_LIST, _param);
            return recordList;
        }
        public async Task<int> CreateStoreAsync(T newStore, CancellationToken cancellationToken)
        {
            var _store = newStore;
            var result = await SqlHelper.Execute(DBUtilities.INSERT_NEW_STORE, cancellationToken: cancellationToken, _store);
            return result;
        }
        public async Task<int> UpdateStoreAsync(T editStore, CancellationToken cancellationToken)
        {
            var _store = editStore;
            return await SqlHelper.Execute(DBUtilities.INSERT_NEW_STORE, cancellationToken: cancellationToken, _store);
        }
    }
}
