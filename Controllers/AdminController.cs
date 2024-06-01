using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Interfaces;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Controllers;

public class AdminController : Controller
{
    private readonly ILoginService _loginService;

    public AdminController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (_loginService.IsValid(model.Username, model.Password))
        {
            // Log the user in (use authentication middleware here)
            return RedirectToAction("Reservations", "Admin");
        }

        ModelState.AddModelError("", "Invalid username or password");
        return View(model);
    }

    public IActionResult Reservations()
    {
        return View();
    }
}