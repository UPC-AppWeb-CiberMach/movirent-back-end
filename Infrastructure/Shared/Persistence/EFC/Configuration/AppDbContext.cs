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

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
   }
}

//suscription