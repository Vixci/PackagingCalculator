using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PackagingCalculatorController : ControllerBase
    {
        private readonly ILogger<PackagingCalculatorController> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IBinWidthCalculator _binWidthCalculator;

        public PackagingCalculatorController(ILogger<PackagingCalculatorController> logger, IOrderRepository orderRepository, IBinWidthCalculator binWidthCalculator)
        {
            _binWidthCalculator = binWidthCalculator;
            _orderRepository = orderRepository;
            _logger = logger;
        }

        //[HttpPut]
        //public IEnumerable<WeatherForecast> Put(List<List<string>> orders,  )
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetSingleOrder))]
        public ActionResult GetSingleOrder(int id)
        {
            Order order = _orderRepository.GetSingle(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost(Name = nameof(AddOrder))]
        public ActionResult<Order> AddOrder([FromBody] int id, OrderCreate orderCreate)
        {

            if (orderCreate == null || _orderRepository.OrderExists(id))
            {
                return BadRequest();
            }

            Order order = new Order
            {
                OrderID = id,
                Items = orderCreate.Items,
                RequiredBinWidth = _binWidthCalculator.calculateMinimumBinWidth(orderCreate.Items)
            };

            _orderRepository.Add(order);

            return order;
            //FoodEntity toAdd = _mapper.Map<FoodEntity>(foodCreateDto);

            //_foodRepository.Add(toAdd);

            //if (!_foodRepository.Save())
            //{
            //    throw new Exception("Creating a fooditem failed on save.");
            //}

            //FoodEntity newFoodItem = _foodRepository.GetSingle(toAdd.Id);

            //return CreatedAtRoute(nameof(GetSingleFood),
            //    new { version = version.ToString(), id = newFoodItem.Id },
            //    _mapper.Map<FoodDto>(newFoodItem));
        }
    }
}
