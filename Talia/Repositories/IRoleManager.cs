using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Talia.Models;

namespace Talia.Repositories
{
    public interface IRoleManager<TRole>: IDisposable where TRole : class
    {
        Task<int> NewUserRoleAsync(TRole role, CancellationToken cancellationToken);
        Task<int> DeleteUserRoleAsync(TRole role, CancellationToken cancellationToken);
        Task<IEnumerable<string>> GetUserRolesAsync(string userId);
    }
}
