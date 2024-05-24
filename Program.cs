using Microsoft.EntityFrameworkCore;
using ReserveSystem.Database;
using ReserveSystem.Interfaces;
using ReserveSystem.Models;
using ReserveSystem.Services;

namespace ReserveSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); // Vytvoří instanci WebApplicationBuilder, která je použita k nastavení a konfiguraci aplikace

        // Načtení connection string z appsettings.json
        var connectionString = builder.Configuration.GetConnectionString("AppConnectionString"); // Načte connection string s názvem "AppConnectionString" z konfiguračního souboru

        // Konfigurace DbContext
        builder.Services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(connectionString)); // Přidá MyDbContext do DI kontejneru a nakonfiguruje ho pro použití SQL Serveru s načteným connection stringem

        // Registrace vašich služeb v DI kontejneru
        builder.Services.AddScoped<IReservationService, ReservationService>(); // Přidá službu ReservationService s životností Scoped
        builder.Services.AddScoped<IPricingService, PricingService>(); // Přidá službu PricingService s životností Scoped
        builder.Services.AddScoped<IServiceService, ServiceService>(); // Přidá službu ServiceService s životností Scoped
        builder.Services.AddScoped<ILoginService, LoginService>(); // Přidá službu LoginService s životností Scoped

        // Přidání služeb pro kontrolery, MVC apod.
        builder.Services.AddControllersWithViews(); // Přidá podporu pro kontrolery a MVC pohledy

        var app = builder.Build(); // Vytvoří instanci WebApplication, která je použita pro konfiguraci middleware a spuštění aplikace

        // Další konfigurace middleware apod.
        if (!app.Environment.IsDevelopment()) // Pokud aplikace není v režimu vývoje
        {
            app.UseExceptionHandler("/Home/Error"); // Použije obecnou stránku s chybami
            app.UseHsts(); // Povolení HTTP Strict Transport Security (HSTS)
        }

        app.UseHttpsRedirection(); // Přesměrování HTTP na HTTPS
        app.UseStaticFiles(); // Slouží statické soubory (CSS, JavaScript, obrázky)

        app.UseRouting(); // Přidává podporu pro směrování

        app.UseAuthorization(); // Přidává podporu pro autorizaci

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"); // Mapuje cesty na kontrolery s defaultní cestou "{controller=Home}/{action=Index}/{id?}"

        app.Run(); // Spustí aplikaci
    }
}