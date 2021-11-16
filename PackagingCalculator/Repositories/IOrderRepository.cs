using System.Collections.Generic;
using System.Linq;
using PackagingCalculator.Entities;

namespace PackagingCalculator.Repositories
{
    public interface IOrderRepository
    {
        Order GetSingle(int id);
        void Add(Order order);
        bool OrderExists(int id);
        bool Save();
    }
}
