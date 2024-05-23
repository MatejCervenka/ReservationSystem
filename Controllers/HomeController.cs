using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}