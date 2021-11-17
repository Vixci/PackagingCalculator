using System;
using System.Collections.Generic;
using System.Linq;
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

        public Order GetSingle(Guid id)
        {
            return _orderDbContext.Orders.FirstOrDefault(x => x.OrderID == id);
        }

        public void Add(Order order)
        {
            _orderDbContext.Orders.Add(order);
            
        }

        public bool OrderExists(Guid id)
        {
            return _orderDbContext.Orders.Any(x => x.OrderID == id);
        }

        public bool Save()
        {
            return (_orderDbContext.SaveChanges() >= 0);
        }
    }
}