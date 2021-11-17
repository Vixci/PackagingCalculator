using System;
using System.Collections.Generic;
using System.Linq;
using PackagingCalculator.Entities;

namespace PackagingCalculator.Repositories
{
    public interface IOrderRepository
    {
        Order GetSingle(Guid id);
        void Add(Order order);
        bool OrderExists(Guid id);
        bool Save();
    }
}
