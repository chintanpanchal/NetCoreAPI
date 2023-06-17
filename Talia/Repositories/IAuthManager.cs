using System.Threading.Tasks;

namespace Talia.Repositories
{
    public interface IAuthManager
    {
        Task<bool> ValidateCredentials(string Username, string Password);
        string GenerateToken();
    }
}
