using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) :DbContext (options)
{
   private readonly IConfiguration _configuration;
   public AppDbContext(IConfiguration configuration)
   {       
      _configuration = configuration;
   }

   public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
   {       
      _configuration = configuration;
   }

   public DbSet<Scooter> Scooter { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      if (!optionsBuilder.IsConfigured)
         optionsBuilder.UseMySQL(_configuration["ConnectionStrings:MovirentPlatformConnection"]);
   }
   
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);

      //completeName, dni, age, phone, email, password, role, photo, address
      builder.Entity<Scooter>().ToTable("Scooter")
         .Property(c => c.CompleteName).IsRequired();
   }
}