
using Domain.Renting.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) :DbContext (options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       if (optionsBuilder == null)
       {
           throw new Exception("Plase provide a valid connection string");
       }
       optionsBuilder.AddInterceptors();
       base.OnConfiguring(optionsBuilder);
   }
   
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      builder.Entity<ScooterVehicle>().ToTable("scooters");
      builder.Entity<ScooterVehicle>().HasKey(s => s.Id);
      builder.Entity<ScooterVehicle>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<ScooterVehicle>().Property(s => s.Name).IsRequired();
      builder.Entity<ScooterVehicle>().Property(s => s.Brand).IsRequired();
      builder.Entity<ScooterVehicle>().Property(s => s.Model).IsRequired();
      builder.Entity<ScooterVehicle>().Property(s => s.Image).IsRequired();
      builder.Entity<ScooterVehicle>().Property(s => s.PricePerHour).IsRequired();
      builder.Entity<ScooterVehicle>().Property(s => s.District).IsRequired();
      builder.Entity<ScooterVehicle>().Property(s => s.Phone).IsRequired();
      
      
   }
}