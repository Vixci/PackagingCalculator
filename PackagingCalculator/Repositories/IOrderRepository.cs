using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PackagingCalculator.Entities;

namespace PackagingCalculator.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetSingle(long id);
        void Add(Order order);
        bool OrderExists(long id);
        bool Save();
    }
}
