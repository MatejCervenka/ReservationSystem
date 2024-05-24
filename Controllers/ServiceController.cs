using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Interfaces;

namespace ReserveSystem.Controllers;

public class ServiceController : Controller
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public IActionResult Index()
    {
        return View();
    }
}