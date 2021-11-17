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
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .Navigation(o => o.Items)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}