using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace rte.Data
{
    public class DataContext : DbContext
    {

        public DataContext() {}
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Volunteering>()
            .Property(v => v.Responsibilities)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

            modelBuilder.Entity<Volunteering>()
                .Property(v => v.Benefits)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            base.OnModelCreating(modelBuilder);
        }    

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Volunteering> Volunteerings { get; set; }
        public DbSet<CampaingnDonation> CampaingnDonations { get; set; }
        public DbSet<VolunteeringRegistration> VolunteeringRegistrations { get; set; }
    }
}