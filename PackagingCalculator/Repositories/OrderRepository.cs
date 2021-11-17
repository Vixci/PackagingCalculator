using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PackagingCalculator.Entities;

namespace PackagingCalculator.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<Order> GetSingle(long id)
        {
            var result = await _orderDbContext.Orders.FindAsync(id);
            return result;
        }

        public void Add(Order order)
        {
            _orderDbContext.Orders.Add(order);
            
        }

        public bool OrderExists(long id)
        {
            return _orderDbContext.Orders.Any(x => x.OrderID == id);
        }

        public bool Save()
        {
            return (_orderDbContext.SaveChanges() >= 0);
        }
    }
}