using Microsoft.EntityFrameworkCore;

namespace Resido.API.Models
{
    public class ResidoDbContext : DbContext
    {
        public ResidoDbContext(DbContextOptions<ResidoDbContext> options)
            : base(options) { }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RentalContract> RentalContracts { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Property
            modelBuilder.Entity<Property>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(200);
                e.Property(x => x.Address).IsRequired().HasMaxLength(500);
            });

            // Room
            modelBuilder.Entity<Room>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).IsRequired().HasMaxLength(50);
                e.Property(x => x.Status).HasMaxLength(50);
                e.Property(x => x.RentPrice).HasColumnType("decimal(18,2)");
                e.Property(x => x.ElectricPrice).HasColumnType("decimal(18,2)");
                e.Property(x => x.WaterPrice).HasColumnType("decimal(18,2)");
                e.Property(x => x.ServiceFee).HasColumnType("decimal(18,2)");

                // Quan hệ Room -> Property
                e.HasOne(x => x.Property)
                 .WithMany(x => x.Rooms)
                 .HasForeignKey(x => x.PropertyId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
