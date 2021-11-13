using Microsoft.EntityFrameworkCore;
using PackagingCalculator.Entities;

namespace PackagingCalculator.Repositories
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}