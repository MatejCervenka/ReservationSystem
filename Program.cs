using Microsoft.EntityFrameworkCore;
using ReserveSystem.Interfaces;
using ReserveSystem.Models;
using ReserveSystem.Services;

namespace ReserveSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Načtení connection string z appsettings.json
        var connectionString = builder.Configuration.GetConnectionString("AppConnectionString");

        // Konfigurace DbContext
        builder.Services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Registrace vašich služeb v DI kontejneru
        builder.Services.AddScoped<IReservationService, ReservationService>();
        builder.Services.AddScoped<IPricingService, PricingService>();
        builder.Services.AddScoped<IServiceService, ServiceService>();
        builder.Services.AddScoped<ILoginService, LoginService>();

        // Přidání služeb pro kontrolery, MVC apod.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Další konfigurace middleware apod.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}