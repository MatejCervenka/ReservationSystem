using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Interfaces;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Controllers;

public class LoginController : Controller
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
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
            // Pokud validace selže, vrátíme uživatele zpět na formulář s chybami
            return View(model);
        }
        return RedirectToAction("Index", "Home");
    }
}