using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Talia.Repositories
{
    public interface IUserManager<TUser> : IDisposable where TUser : class
    {
        Task<int> CreateAsync(TUser user, CancellationToken cancellationToken);
        Task<TUser> UpdateAsync(TUser newUser, CancellationToken cancellationToken);
        Task<int> DeleteAsync(string Id, CancellationToken cancellationToken);
        Task<TUser> GetUserByIdAsync(string Id, CancellationToken cancellationToken);
        Task<string> GetUserIdAsync(string userName);
        Task<IEnumerable<TUser>> GetActiveUsersAsync(CancellationToken cancellationToken);
    }
}
