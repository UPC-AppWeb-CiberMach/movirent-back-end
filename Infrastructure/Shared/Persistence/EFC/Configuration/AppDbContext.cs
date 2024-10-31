
using Domain.Renting.Model.Entities;
using Domain.UserHistorial.Model.Entities;
using Domain.Subscription.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) :DbContext (options)
{
    public DbSet<HistorialEntity> Historials { get; set; }
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
      
      builder.Entity<HistorialEntity>().ToTable("historial");
      builder.Entity<HistorialEntity>().HasKey(r => r.Id);
      builder.Entity<HistorialEntity>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<HistorialEntity>().Property(r => r.ScooterId).IsRequired();
      builder.Entity<HistorialEntity>().Property(r => r.UserId).IsRequired();
      builder.Entity<HistorialEntity>().Property(r => r.StartTime).IsRequired();
      builder.Entity<HistorialEntity>().Property(r => r.EndTime).IsRequired();
      builder.Entity<HistorialEntity>().Property(r => r.Price).IsRequired();
      builder.Entity<HistorialEntity>().Property(r => r.Time).IsRequired();
      builder.Entity<HistorialEntity>().Property(r => r.CreatedDate).IsRequired().HasColumnType("datetime");
      
      base.OnModelCreating(builder);
      builder.Entity<SubscriptionEntity>().ToTable("subscriptions");
      builder.Entity<SubscriptionEntity>().HasKey(s => s.Id);
      builder.Entity<SubscriptionEntity>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<SubscriptionEntity>().Property(s => s.Name).IsRequired();
      builder.Entity<SubscriptionEntity>().Property(s => s.Description).IsRequired();
      builder.Entity<SubscriptionEntity>().Property(s => s.Price).IsRequired();
      builder.Entity<SubscriptionEntity>().Property(s => s.Stars).IsRequired();
   }
}