using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Talia.Helper;
using Talia.Models;
using Talia.Repositories;

namespace Talia.Controllers
{
    //[Route("[Controller]")]
    public class AuthTokenController : ControllerBase
    {
        public readonly IAuthManager _iAuth;
        public AuthTokenController(IAuthManager iAuth) => _iAuth = iAuth;
        [HttpPost]
        [Route("/")]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            var credentials = new { user.UserName, user.Password };
            if (!ModelState.IsValid) return ValidationProblem();
            if (!await _iAuth.ValidateCredentials(credentials.UserName, credentials.Password))
                return Unauthorized(new { message = ErrorHelper.INVALID_USER_CREDENTIALS_MESSAGE });
            var data = _iAuth.GenerateToken();
            return Ok(new
            {
                response = data,
                statusCode = HttpContext.Response.StatusCode
            });
        }
    }
}
