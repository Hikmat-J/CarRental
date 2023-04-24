using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace CarRental.EntityFrameworkCore
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=CarRental;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .HasOne(e => e.User)
            .WithOne(e => e.Customer)
            .HasForeignKey<Customer>(e => e.Id)
            .IsRequired();

            modelBuilder.Entity<Driver>()
            .HasOne(e => e.User)
            .WithOne(e => e.Driver)
            .HasForeignKey<Driver>(e => e.Id)
            .IsRequired();

            modelBuilder.Entity<Car>()
            .HasOne(e => e.Driver)
            .WithOne(e => e.Car)
            .HasForeignKey<Car>(car => car.DriverId)
            .IsRequired(false); 

            modelBuilder.Entity<Car>()
                .HasIndex(e => e.Number)
                .IsUnique();

            modelBuilder.Entity<Car>()
                    .HasMany(e => e.AlternativeDrivers)
                    .WithMany(e => e.AlternativeCars)
                    .UsingEntity<AlternativeDriving>(
                        l => l.HasOne<Driver>(e => e.Driver).WithMany(e => e.AlternativeDriving).HasForeignKey(e => e.DriverId),
                        r => r.HasOne<Car>(e => e.Car).WithMany(e => e.AlternativeDrivering).HasForeignKey(e => e.CarId)
                        );

            modelBuilder.Entity<Car>()
                    .HasMany(e => e.Customers)
                    .WithMany(e => e.Cars)
                    .UsingEntity<Rent>(
                        l => l.HasOne<Customer>(e => e.Customer).WithMany(e => e.RentCars).HasForeignKey(e => e.CustomerId),
                        r => r.HasOne<Car>(e => e.Car).WithMany(e => e.Rents).HasForeignKey(e => e.CarId));


            //            modelBuilder.Entity<Driver>()
            //.HasMany(e => e.SubstituteDriving)
            //.WithOne(e => e.SubstititeDriver)
            //.HasForeignKey(e => e.SubstituteDriverId)
            //.IsRequired(false);

            //    modelBuilder.Entity<Rent>()
            //    .HasOne(e => e.Customer)
            //    .WithMany(e => e.Rents)
            //    .HasForeignKey(rent => rent.CustomerId)
            //    .IsRequired(true);

            //    modelBuilder.Entity<Rent>()
            //    .HasOne(e => e.Car)
            //    .WithMany(e => e.Rents)
            //    .HasForeignKey(rent => rent.CarId)
            //.IsRequired(true);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Customer> Drivers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }


    }

}
