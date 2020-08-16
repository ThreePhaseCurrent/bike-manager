using Microsoft.EntityFrameworkCore;

namespace BikeManager.Core.Models
{
    public class BikeManagerDbContext: DbContext
    {
        public BikeManagerDbContext(DbContextOptions<BikeManagerDbContext> options): base(options)
        {
        }
        
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<BikeCategory> BikeCategories { get; set; }
        public DbSet<BikeStatus> BikeStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bike>().HasKey(e => e.BikeId);
            modelBuilder.Entity<Bike>(entity =>
            {
                entity.Property(e => e.BikeId).ValueGeneratedOnAdd();
                entity.Property(e => e.BikeName).IsRequired();
                entity.Property(e => e.CategoryId).IsRequired();
                entity.Property(e => e.StatusId).IsRequired();
                entity.Property(e => e.Price).IsRequired();

                entity.HasOne(e => e.Category)
                    .WithMany(e => e.Bikes)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Status)
                    .WithMany(e => e.Bikes)
                    .HasForeignKey(e => e.StatusId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<BikeCategory>().HasKey(e => e.CategoryId);
            modelBuilder.Entity<BikeCategory>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();
                entity.Property(e => e.CategoryName).IsRequired();
            });
            
            modelBuilder.Entity<BikeStatus>().HasKey(e => e.StatusId);
            modelBuilder.Entity<BikeStatus>(entity =>
            {
                entity.Property(e => e.StatusId).ValueGeneratedOnAdd();
                entity.Property(e => e.StatusName).IsRequired();
            });
        }
    }
}