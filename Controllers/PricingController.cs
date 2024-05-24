using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Interfaces;

namespace ReserveSystem.Controllers;

public class PricingController : Controller
{
    private readonly IPricingService _pricingService;

    public PricingController(IPricingService pricingService)
    {
        _pricingService = pricingService;
    }

    public IActionResult Index()
    {
        _pricingService.MyMethod();
        return View();
    }
}