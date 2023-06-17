using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Talia.Helper;
using Talia.Models;
using Talia.Repositories;

namespace Talia.Controllers
{
    [Route("[Controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrder<Orders> _userOrder;
        public OrderController(IOrder<Orders> userOrders) => _userOrder = userOrders;
        [Route("add")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] Orders _newOrder, CancellationToken Token)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            await _userOrder.CreateOrderAsync(_newOrder, Token);
            return Ok(new { Message = ErrorHelper.DATA_INSERT_SUCCESS_MESSAGE });
        }
        [Route("Update")]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] Orders _newOrder, CancellationToken Token)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            await _userOrder.UpdateOrderAsync(_newOrder, Token);
            return Ok(new { Message = ErrorHelper.DATA_INSERT_SUCCESS_MESSAGE });
        }
    }
}
