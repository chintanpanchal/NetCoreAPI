using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Talia.Attributes;
using Talia.Helper;
using Talia.Models;
using Talia.Repositories;

namespace Talia.Controllers
{
    [Route("[Controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreManager<StoreDetails> _store;
        public StoreController(IStoreManager<StoreDetails> store) => _store = store;
        [AuthorizeRoles(Role.Executive, Role.Admin)]
        [HttpGet]
        [Route("data/{id}")]
        public async Task<IActionResult> GetStoreByIdAsync(string Id, CancellationToken Token)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            var data = await _store.GetStoreByIdAsync(Id, Token);
            return Ok(new
            {
                response = data,
                statusCode = HttpContext.Response.StatusCode
            });
        }
        [AuthorizeRoles(Role.Executive, Role.Admin)]
        [HttpGet]
        [Route("data")]
        public async Task<IActionResult> GetStoreAsync(CancellationToken Token)
        {
            var data = await _store.GetStoreAsync(Token);
            return Ok(new
            {
                response = data,
                statusCode = HttpContext.Response.StatusCode,
            });
        }
        [AuthorizeRoles(Role.Admin)]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateStoreAsync([FromBody] StoreDetails storeDetails, CancellationToken Token)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            await _store.CreateStoreAsync(storeDetails, Token);
            return Ok(new
            {
                Message = ErrorHelper.DATA_INSERT_SUCCESS_MESSAGE,
                statusCode = HttpContext.Response.StatusCode
            });
        }
        [AuthorizeRoles(Role.Admin)]
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateStoreAsync([FromBody] StoreDetails storeDetails, CancellationToken Token)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            await _store.UpdateStoreAsync(storeDetails, Token);
            return Ok(new
            {
                Message = ErrorHelper.DATA_UPDATE_SUCCESS_MESSAGE,
                statusCode = HttpContext.Response.StatusCode
            });
        }
        [AuthorizeRoles(Role.Admin)]
        [HttpPost]
        [Route("delete/{storeid}")]
        public async Task<IActionResult> DeleteStoreAsync(int storeId, CancellationToken Token)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            await _store.DeleteStoreAsync(storeId, Token);
            return Ok(new
            {
                Message = ErrorHelper.DATA_SUCCESS_DELETION_MESSAGE,
                statusCode = HttpContext.Response.StatusCode
            });
        }
    }
}
