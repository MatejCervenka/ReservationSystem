using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Database;

public class MyDbContext : DbContext
{
    // Definujte DbSety pro vaše entity
     public DbSet<Reservation?> Reservations { get; set; }
     public DbSet<Pricing?> Pricings { get; set; }
     public DbSet<Service?> Services { get; set; }
     public DbSet<Login?> Logins { get; set; }
    
     public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.UseCollation("Latin1_General_100_CI_AS_SC_UTF8");
    }
}