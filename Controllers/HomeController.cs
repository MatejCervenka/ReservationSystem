using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Database;
using ReserveSystem.Models;

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
        return View();
    }
}