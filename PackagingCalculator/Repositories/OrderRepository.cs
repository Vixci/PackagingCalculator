﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            var result = await _orderDbContext.Orders
                .Include(order => order.Items)
                .FirstOrDefaultAsync(order => order.OrderId == id);

            return result;
        }

        public async Task<int> Save(Order order)
        {
            _orderDbContext.Orders.Add(order);

            foreach (Item item in order.Items)
            {
                _orderDbContext.Items.Add(item);
            }

            return await _orderDbContext.SaveChangesAsync();
        }

        public bool Exists(long id)
        {
            return _orderDbContext.Orders.Any(x => x.OrderId == id);
        }
    }
}