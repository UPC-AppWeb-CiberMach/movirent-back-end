
using Domain.IAM.Model.Entities;
using Domain.Renting.Model.Entities;
using Domain.Reservation.Model.Entities;
using Domain.Subscription.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) :DbContext (options)
{
    public DbSet<ReservationEntity> Reservations { get; set; }
    
    public DbSet<ScooterVehicle> Scooters { get; set; }
    
    public DbSet<SubscriptionEntity> Subscriptions { get; set; }
    
    public DbSet<UserProfile> Users { get; set; }
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
      
      builder.Entity<ReservationEntity>().ToTable("history");
      builder.Entity<ReservationEntity>().HasKey(r => r.Id);
      builder.Entity<ReservationEntity>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<ReservationEntity>().Property(r => r.ScooterId).IsRequired();
      builder.Entity<ReservationEntity>().Property(r => r.UserId).IsRequired();
      builder.Entity<ReservationEntity>().Property(r => r.StartTime).IsRequired();
      builder.Entity<ReservationEntity>().Property(r => r.EndTime).IsRequired();
      builder.Entity<ReservationEntity>().Property(r => r.CreatedDate).IsRequired().HasColumnType("datetime");
      
      base.OnModelCreating(builder);
      builder.Entity<SubscriptionEntity>().ToTable("subscriptions");
      builder.Entity<SubscriptionEntity>().HasKey(s => s.Id);
      builder.Entity<SubscriptionEntity>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<SubscriptionEntity>().Property(s => s.Name).IsRequired();
      builder.Entity<SubscriptionEntity>().Property(s => s.Description).IsRequired();
      builder.Entity<SubscriptionEntity>().Property(s => s.Price).IsRequired();
      builder.Entity<SubscriptionEntity>().Property(s => s.Stars).IsRequired();
      
      base.OnModelCreating(builder);
      builder.Entity<UserProfile>().ToTable("users");
      builder.Entity<UserProfile>().HasKey(u => u.id);
      builder.Entity<UserProfile>().Property(u => u.id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<UserProfile>().Property(u => u.email).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.password).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.completeName).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.phone).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.dni).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.photo).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.address).IsRequired();
   }
}