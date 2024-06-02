using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Database
{
    // Kontext databáze pro aplikaci, odvozený z DbContext
    public class MyDbContext : DbContext
    {
        // Definice DbSetů pro entity v databázi
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Login> Logins { get; set; }

        // Konstruktor s injektovanými možnostmi DbContextu
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        
        // Konfigurace modelu v databázi
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Použití určené kolace pro databázi
            builder.UseCollation("Latin1_General_100_CI_AS_SC_UTF8");
        }
    }
}