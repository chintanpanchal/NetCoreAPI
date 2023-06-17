using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Talia.Helper;
using Talia.Models;
using Talia.Repositories;

namespace Talia.Controllers
{
    [Route("[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserManager<UserDetails> _userStore;
        public AccountController(IUserManager<UserDetails> userStore) => _userStore = userStore;
        [HttpGet]
        [Route("data/{id}")]
        public async Task<IActionResult> RetriveUserAsync(string UserId, CancellationToken Token)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            var data = await _userStore.GetUserByIdAsync(UserId, Token);
            return Ok(new
            {
                response = data,
                statusCode = HttpContext.Response.StatusCode
            });
        }
        [HttpGet]
        [Route("data")]
        public async Task<IActionResult> RetriveActiveUserAsync(CancellationToken Token)
        {
            var data = await _userStore.GetActiveUsersAsync(Token);
            return Ok(new
            {
                response = data,
                statusCode = HttpContext.Response.StatusCode
            });
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserDetails _newUser, CancellationToken Token)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            await _userStore.CreateAsync(_newUser, Token);
            return Ok(new { Message = ErrorHelper.DATA_INSERT_SUCCESS_MESSAGE });
        }
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserDetails _editUser, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            return Ok(await _userStore.UpdateAsync(_editUser, cancellationToken));
        }
        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteUserAsync(string UserId, CancellationToken Token)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            await _userStore.DeleteAsync(UserId, Token);
            return Ok(new { Message = ErrorHelper.DATA_SUCCESS_DELETION_MESSAGE });
        }
    }
}
