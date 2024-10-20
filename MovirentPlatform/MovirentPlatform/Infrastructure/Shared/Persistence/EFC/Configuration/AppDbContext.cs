using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) :DbContext (options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.AddInterceptors();
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
   }
}