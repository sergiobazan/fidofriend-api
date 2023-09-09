using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Pet> Pets { get; set; }

        public virtual DbSet<ClinicalRecord> ClinicalRecords { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<ServiceVet> ServicesVet { get; set; }

        public virtual DbSet<Meeting> Meetings { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Pets)
                .WithOne(e => e.Owner)
                .HasForeignKey(e => e.OwnerId)
                .IsRequired();

            modelBuilder.Entity<Pet>()
                .HasMany(e => e.ClinicalRecords)
                .WithOne(e => e.Pet)
                .HasForeignKey(e => e.PetId)
                .IsRequired();
        }
    }
}
