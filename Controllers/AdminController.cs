using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Interfaces;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Controllers
{
    // Kontrolér pro obsluhu HTTP požadavků administrátorského rozhraní
    public class AdminController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IAdminService _adminService;

        // Konstruktor kontroléru s injektovanými službami pro přihlášení a administraci
        public AdminController(ILoginService loginService, IAdminService adminService)
        {
            _loginService = loginService;
            _adminService = adminService;
        }

        // Metoda pro zobrazení stránky pro přihlášení administrátora
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Metoda pro ověření přihlašovacích údajů administrátora
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // Pokud validace modelu neproběhne úspěšně, zobrazí se opět formulář s chybami
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Pokud jsou přihlašovací údaje platné, uživatele přesměruje na stránku s rezervacemi
            if (_loginService.IsValid(model.Username, model.Password))
            {
                // Provede přihlášení uživatele (zde použijte autentizační middleware)
                return RedirectToAction("Reservations", "Admin");
            }

            // Pokud jsou přihlašovací údaje neplatné, zobrazí se chybová zpráva
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        // Metoda pro zobrazení seznamu rezervací
        public IActionResult Reservations()
        {
            // Získání viewModelu seznamu rezervací pomocí administrační služby
            var viewModel = _adminService.GetReservationsListViewModel();
            return View(viewModel);
        }
    }
}
