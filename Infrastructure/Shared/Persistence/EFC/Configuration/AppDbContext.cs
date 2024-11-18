
using Domain.IAM.Model.Entities;
using Domain.Renting.Model.Entities;
using Domain.Review.Model.Entities;
using Domain.UserHistorial.Model.Entities;
using Domain.Subscription.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) :DbContext (options)
{
    public DbSet<HistoryEntity> Histories { get; set; }
    
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
      
      base.OnModelCreating(builder);

      builder.Entity<HistoryEntity>().ToTable("histories");
      builder.Entity<HistoryEntity>().HasKey(h => h.Id);
      builder.Entity<HistoryEntity>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<HistoryEntity>().Property(h => h.ClientId).IsRequired();
      builder.Entity<HistoryEntity>().Property(h => h.ScooterId).IsRequired();
      builder.Entity<HistoryEntity>().Property(h => h.StartDate).IsRequired();
      builder.Entity<HistoryEntity>().Property(h => h.EndDate).IsRequired();
      builder.Entity<HistoryEntity>().Property(h => h.Price).IsRequired();
      builder.Entity<HistoryEntity>().Property(h => h.Time).IsRequired();

      
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
      builder.Entity<UserProfile>().HasKey(u => u.Id);
      builder.Entity<UserProfile>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<UserProfile>().Property(u => u.Email).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.Password).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.CompleteName).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.Phone).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.Dni).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.Photo).IsRequired();
      builder.Entity<UserProfile>().Property(u => u.Address).IsRequired();
      
      base.OnModelCreating(builder);
        builder.Entity<ReviewEntity>().ToTable("reviews");
        builder.Entity<ReviewEntity>().HasKey(r => r.Id);
        builder.Entity<ReviewEntity>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ReviewEntity>().Property(r => r.Comment).IsRequired();
        builder.Entity<ReviewEntity>().Property(r => r.StarNumb).IsRequired();
   }
}