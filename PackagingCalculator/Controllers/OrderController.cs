using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PackagingCalculator.Repositories;
using PackagingCalculator.Helpers;
using PackagingCalculator.Entities;

namespace PackagingCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IBinWidthCalculator _binWidthCalculator;

        public OrderController(ILogger<OrderController> logger, IOrderRepository orderRepository, IBinWidthCalculator binWidthCalculator)
        {
            _binWidthCalculator = binWidthCalculator;
            _orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetSingleOrder))]
        public async Task<ActionResult<Order>> GetSingleOrder(long id)
        {
            Order order = await _orderRepository.GetSingle(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost(Name = nameof(AddOrder))]
        public async Task<ActionResult<Order>> AddOrder([FromBody] OrderCreate orderCreate)
        {

            if (orderCreate == null)
            {
                return BadRequest();
            }

            Order order = new Order
            {
                Items = orderCreate.Items,
                RequiredBinWidth = _binWidthCalculator.calculateMinimumBinWidth(orderCreate.Items)
            };

            await _orderRepository.Save(order);

            return CreatedAtAction("GetSingleOrder", new { id = order.OrderId }, order);
        }
    }
}
