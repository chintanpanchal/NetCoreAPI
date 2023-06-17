using Talia.Models;
using Talia.Repositories;
using Talia.Connection;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.Generic;
using Talia.Helper;

namespace Talia.DataAccess
{
    public class UserDataAcess<T> : IUserManager<T> where T : UserDetails, new()
    {
        public async Task<int> CreateAsync(T user, CancellationToken cancellationToken)
        {
            object _param = new { user.UserName, user.Email, user.Password, user.Id };
            return await SqlHelper.Execute(DBUtilities.INSERT_NEW_APP_USER, cancellationToken, _param);
        }

        public async Task<int> DeleteAsync(string Id, CancellationToken cancellationToken)
        {
            object _param = new { UserId = Id };
            return await SqlHelper.Execute(DBUtilities.DELETE_APP_USER, cancellationToken, _param);
        }

        public async Task<IEnumerable<T>> GetActiveUsersAsync(CancellationToken cancellationToken) => await SqlHelper.GetRecords<T>(DBUtilities.GET_APP_USER);

        public async Task<T> GetUserByIdAsync(string Id, CancellationToken cancellationToken)
        {
            object param = new { ID = Id };
            return await SqlHelper.GetRecord<T>(DBUtilities.GET_APP_USER, param);
        }

        public async Task<T> UpdateAsync(T edit, CancellationToken cancellationToken)
        {
            object _param = new { ID = edit.Id, Email = edit.Email };
            await SqlHelper.Execute(DBUtilities.UPDATE_APP_USER, cancellationToken, _param);
            return await GetUserByIdAsync(edit.Id, cancellationToken);
        }
        public void Dispose() => throw new NotImplementedException();

        public async Task<string> GetUserIdAsync(string userName)
        {
            object _param = new { UserName = userName };
            return await SqlHelper.GetRecord<string>(DBUtilities.GET_CURRENT_USER_ID, _param);
        }
    }
}
