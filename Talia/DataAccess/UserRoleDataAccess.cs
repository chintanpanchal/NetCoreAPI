using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Talia.Connection;
using Talia.Helper;
using Talia.Models;
using Talia.Repositories;

namespace Talia.DataAccess
{
    public class UserRoleDataAccess<T> : IRoleManager<T> where T : UserRoles, new()
    {
        public Task<int> DeleteUserRoleAsync(T role, CancellationToken cancellationToken)
        {
            object _param = new { role.UserID, role.RoleName };
            return SqlHelper.Execute(DBUtilities.DELETE_USER_FROM_ROLES, cancellationToken, _param);
        }
        public async Task<IEnumerable<string>> GetUserRolesAsync(string UserID)
        {
            object param = new { UserID };
            return (await SqlHelper.GetRecords<string>(DBUtilities.GET_USER_ROLES, param));
        }
        public Task<int> NewUserRoleAsync(T role, CancellationToken cancellationToken)
        {
            object _param = new { role.UserID, role.RoleName };
            return SqlHelper.Execute(DBUtilities.ADD_USER_TO_ROLES, cancellationToken, _param);
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
