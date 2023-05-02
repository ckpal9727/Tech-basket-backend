using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace Practice.API.DbContexts
{
    public class InfoContext : DbContext
    {
        public DbSet<Users> User { get; set; }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payment { get; set; } 
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryInformation> DeliveryInformation { get; set; }
        public InfoContext(DbContextOptions<InfoContext> options) : base(options)
        {

        }
    }
}
