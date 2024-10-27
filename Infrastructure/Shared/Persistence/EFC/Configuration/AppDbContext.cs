using Domain.Suscription.Model.Entities;
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
      builder.Entity<SuscriptionEntity>().ToTable("suscription");
      builder.Entity<SuscriptionEntity>().HasKey(s => s.Id);
      builder.Entity<SuscriptionEntity>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<SuscriptionEntity>().Property(s => s.Name).IsRequired();
      builder.Entity<SuscriptionEntity>().Property(s => s.Description).IsRequired();
      builder.Entity<SuscriptionEntity>().Property(s => s.Stars).IsRequired();
      builder.Entity<SuscriptionEntity>().Property(s => s.Price).IsRequired();
   }
}

//suscription