using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SStore.Model.Data.Entities;

namespace SStore.Model.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory>  ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }  
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }          
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMathod> PaymentMathods { get; set; }

    }

  

}