
using Domain.IAM.Model.Entities;
using Domain.Renting.Model.Entities;
using Domain.Review.Model.Entities;
using Domain.UserHistorial.Model.Entities;
using Domain.Subscription.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) :DbContext (options)
{
    public DbSet<HistorialEntity> Historials { get; set; }
    
    public DbSet<ScooterEntity> Scooters { get; set; }
    
    public DbSet<SubscriptionEntity> Subscriptions { get; set; }
    
    public DbSet<UserProfile> Users { get; set; }
    
    public DbSet<ReviewEntity> Reviews { get; set; }
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       if (optionsBuilder == null)
       {
           throw new Exception("Please provide a valid connection string");
       }
       optionsBuilder.AddInterceptors();
       base.OnConfiguring(optionsBuilder);
   }
   
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      builder.Entity<ScooterEntity>().ToTable("scooters");
      builder.Entity<ScooterEntity>().HasKey(s => s.Id);
      builder.Entity<ScooterEntity>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<ScooterEntity>().Property(s => s.Name).IsRequired();
      builder.Entity<ScooterEntity>().Property(s => s.Brand).IsRequired();
      builder.Entity<ScooterEntity>().Property(s => s.Model).IsRequired();
      builder.Entity<ScooterEntity>().Property(s => s.Image).IsRequired();
      builder.Entity<ScooterEntity>().Property(s => s.PricePerHour).IsRequired();
      builder.Entity<ScooterEntity>().Property(s => s.District).IsRequired();
      builder.Entity<ScooterEntity>().Property(s => s.Phone).IsRequired();
      
      builder.Entity<HistorialEntity>().ToTable("history");
      builder.Entity<HistorialEntity>().HasKey(r => r.Id);
      builder.Entity<HistorialEntity>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<HistorialEntity>().Property(r => r.ScooterId).IsRequired();
      builder.Entity<HistorialEntity>().Property(r => r.UserId).IsRequired();
      builder.Entity<HistorialEntity>().Property(r => r.StartTime).IsRequired();
      builder.Entity<HistorialEntity>().Property(r => r.EndTime).IsRequired();
      builder.Entity<HistorialEntity>().Property(r => r.CreatedDate).IsRequired().HasColumnType("datetime");
      
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
      
      base.OnModelCreating(builder);
        builder.Entity<ReviewEntity>().ToTable("reviews");
        builder.Entity<ReviewEntity>().HasKey(r => r.Id);
        builder.Entity<ReviewEntity>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ReviewEntity>().Property(r => r.Name).IsRequired();
        builder.Entity<ReviewEntity>().Property(r => r.Brand).IsRequired();
        builder.Entity<ReviewEntity>().Property(r => r.Model).IsRequired();
        builder.Entity<ReviewEntity>().Property(r => r.Image).IsRequired();
        builder.Entity<ReviewEntity>().Property(r => r.PricePerHour).IsRequired();
        builder.Entity<ReviewEntity>().Property(r => r.District).IsRequired();
        builder.Entity<ReviewEntity>().Property(r => r.Phone).IsRequired();
       
   }
}