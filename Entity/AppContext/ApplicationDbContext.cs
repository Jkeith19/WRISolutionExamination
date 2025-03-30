using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Entity.AppContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sku> Skus { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.PurchaseOrders)
                .WithOne()
                .HasForeignKey(e => e.CustomerId)
                .IsRequired();

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne<Customer>()
                .WithMany(e => e.PurchaseOrders)
                .HasForeignKey(e => e.CustomerId)
                .IsRequired();

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany<PurchaseItem>()
                .WithOne()
                .HasForeignKey(e => e.PurchaseOrderId)
                .IsRequired();

            modelBuilder.Entity<PurchaseItem>()
                .HasOne<PurchaseOrder>()
                .WithMany(e => e.PurchaseItems)
                .HasForeignKey(e => e.PurchaseOrderId)
                .IsRequired();

            modelBuilder.Entity<Sku>()
                .HasMany<PurchaseItem>()
                .WithOne()
                .HasForeignKey(e => e.SkuId)
                .IsRequired();

            modelBuilder.Entity<PurchaseItem>()
                .HasOne<Sku>()
                .WithMany(e => e.PurchaseItems)
                .HasForeignKey(e => e.SkuId)
                .IsRequired();

            modelBuilder.Entity<Customer>().ToTable(nameof(Customer));

            modelBuilder.Entity<Sku>().ToTable(nameof(Sku));

            modelBuilder.Entity<PurchaseOrder>().ToTable(nameof(PurchaseOrder));

            modelBuilder.Entity<PurchaseItem>().ToTable(nameof(PurchaseItem));
        }
    }
}
