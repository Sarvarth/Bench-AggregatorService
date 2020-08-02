using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AggregatorService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMergerService _mergerService;

        public OrderDetailsController(IMergerService mergerService)
        {
            _mergerService = mergerService;
        }
        // GET orderDetails/5
        [HttpGet("{id}")]
        public async Task<OrderDetails> Get(int id)
        {
            return await _mergerService.GetOrderDetails(id);
        }
    }
}
