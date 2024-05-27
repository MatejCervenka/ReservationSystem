using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Interfaces;

namespace ReserveSystem.Controllers;

public class LoginController : Controller
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    public IActionResult Index()
    {
        return View();
    }
}