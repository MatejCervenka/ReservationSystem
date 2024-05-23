using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.UseCollation("Latin1_General_100_CI_AS_SC_UTF8");
        
        // Konfigurace vztahu mezi Reservation a Service
        builder.Entity<Reservation>()
            .HasOne(r => r.Service)     // Definuje, že entita Reservation má vztah k entitě Service
            .WithMany(s => s.Reservations)  // Definuje, že entita Service může mít více rezervací (jedna služba může mít více rezervací)
            .HasForeignKey(r => r.ServiceId);       // Definuje cizí klíč v entitě Reservation, který odkazuje na primární klíč v entitě Service
        
        builder.Entity<Pricing>(entity =>
        {
            entity.Property(e => e.SaleAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
        });
    }

    // Definujte DbSety pro vaše entity
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Pricing> Pricings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Login> Logins { get; set; }
}