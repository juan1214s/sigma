using Microsoft.EntityFrameworkCore;
using technical_test_sigma.Domain.Entities;

namespace technical_test_sigma.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cliente
            modelBuilder.Entity<CustomerEntity>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<CustomerEntity>()
                .HasOne(c => c.Address)
                .WithOne(d => d.Customer)
                .HasForeignKey<AddressEntity>(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomerEntity>()
                .HasMany(c => c.Payments)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Dirección
            modelBuilder.Entity<AddressEntity>()
                .HasKey(d => d.AddressId);

            // Pago
            modelBuilder.Entity<PaymentEntity>()
                .HasKey(p => p.PaymentId);

            modelBuilder.Entity<PaymentEntity>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}
