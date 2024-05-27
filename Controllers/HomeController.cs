using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Database;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Controllers;

public class HomeController : Controller
{
    private readonly MyDbContext _dbContext;

    public HomeController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IActionResult Index()
    {
        var viewModel = new IndexPageViewModel
        {
            Login = new LoginViewModel
            {
                Id = 1,
                Username = "exampleUser",
                Password = "examplePass",
                CreatedAt = DateTime.Now
            },
            Pricing = new PricingViewModel
            {
                Id = 1,
                Title = "Basic Plan",
                Description = "This is a basic plan.",
                SaleAmount = 49.99M,
                Amount = 59.99M,
                Currency = 'K'
            },
            Reservation = new ReservationViewModel
            {
                Id = 1,
                ServiceId = 1,
                Name = "John",
                Surname = "Doe",
                Phone = "123-456-7890",
                Email = "john.doe@example.com",
                CreatedAt = DateTime.Now,
                ServiceViewModel = new ServiceViewModel
                {
                    Id = 1,
                    Name = "Haircut"
                }
            },
            Service = new ServiceViewModel
            {
                Id = 1,
                Name = "Haircut",
                Reservations = new List<ReservationViewModel>
                {
                    new ReservationViewModel
                    {
                        Id = 1,
                        ServiceId = 1,
                        Name = "John",
                        Surname = "Doe",
                        Phone = "123-456-7890",
                        Email = "john.doe@example.com",
                        CreatedAt = DateTime.Now
                    }
                }
            }
        };

        return View(viewModel);
    }
}