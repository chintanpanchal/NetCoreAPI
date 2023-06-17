using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Talia.Attributes;
using Talia.Helper;
using Talia.Models;
using Talia.Repositories;

namespace Talia.Controllers
{
    [AuthorizeRoles(Role.Admin)]
    [Route("[Controller]")]
    public class UserRolesController : ControllerBase
    {
        private readonly IRoleManager<UserRoles> _iRoleManager;
        public UserRolesController(IRoleManager<UserRoles> roleManager) => _iRoleManager = roleManager;
        [Route("data/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserRolesAsync(string id)
        {
            if (!ModelState.IsValid)
                ValidationProblem();
            var data = await _iRoleManager.GetUserRolesAsync(id);
            return Ok(new
            {
                response = data,
                statusCode = HttpContext.Response.StatusCode
            });
        }
        [Route("add")]
        [HttpPut]
        public async Task<IActionResult> NewUserRoleAsync([FromBody] UserRoles _userRoles, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                ValidationProblem();
            var data = await _iRoleManager.NewUserRoleAsync(_userRoles, cancellationToken);
            return Ok(new
            {
                response = data,
                statusCode = HttpContext.Response.StatusCode
            });
        }
        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserRoleAsync([FromBody] UserRoles _userRoles, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                ValidationProblem();
            var data = await _iRoleManager.DeleteUserRoleAsync(_userRoles, cancellationToken);
            return Ok(new
            {
                response = data,
                statusCode = HttpContext.Response.StatusCode
            });
        }
    }
}
