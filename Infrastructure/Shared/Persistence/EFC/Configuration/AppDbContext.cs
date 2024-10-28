
using Domain.Subscription.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) :DbContext (options)
{
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
      builder.Entity<SubscriptionEntity>().ToTable("subscriptions");
      builder.Entity<SubscriptionEntity>().HasKey(s => s.Id);
      builder.Entity<SubscriptionEntity>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<SubscriptionEntity>().Property(s => s.Name).IsRequired();
      builder.Entity<SubscriptionEntity>().Property(s => s.Description).IsRequired();
      builder.Entity<SubscriptionEntity>().Property(s => s.Price).IsRequired();
      builder.Entity<SubscriptionEntity>().Property(s => s.Stars).IsRequired();
      
   }
}