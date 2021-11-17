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
        bool Exists(long id);
        void Save(Order order);
    }
}
