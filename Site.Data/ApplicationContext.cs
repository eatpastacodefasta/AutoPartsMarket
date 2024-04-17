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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supply> Supplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Supply>().ToTable("Supply");

            modelBuilder.Entity<SupplierProduct>().HasKey(m => new { m.SupplierID, m.ProductID });
        }
    }
}
