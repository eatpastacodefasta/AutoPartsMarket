using Microsoft.EntityFrameworkCore;
using Site.Data.Models;

namespace Site.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Store>().ToTable("Stores");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Supply>().ToTable("Supplies");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Stock>().ToTable("Stock");

            modelBuilder.Entity<SupplierProduct>().HasKey(m => new { m.SupplierID, m.ProductID });
            modelBuilder.Entity<StoreProduct>().HasKey(m => new { m.StoreID, m.ProductID });
        }
    }
}
