using Task6.Models;
using Microsoft.EntityFrameworkCore;

namespace Task6.Controllers
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses {get;set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductWarehouse> ProductWarehouses { get; set; }

        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        {

        }
    }
}
