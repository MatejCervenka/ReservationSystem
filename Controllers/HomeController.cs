using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Interfaces;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Controllers
{
    // Kontrolér pro obsluhu HTTP požadavků na úvodní stránku a vytvoření rezervace
    public class HomeController : Controller
    {
        private readonly IMainService _mainService;

        // Konstruktor kontroléru s injektovanou hlavní službou
        public HomeController(IMainService mainService)
        {
            _mainService = mainService;
        }
        
        // Metoda pro zobrazení úvodní stránky
        public IActionResult Index()
        {
            // Získání viewModelu pro úvodní stránku z hlavní služby
            var viewModel = _mainService.GetIndexViewModel();
            return View(viewModel);
        }

        // Metoda pro vytvoření nové rezervace
        [HttpPost]
        [Route("/create-reservation")]
        public IActionResult CreateReservation(ReservationViewModel viewModel)
        {
            try
            {
                // Vytvoření rezervace pomocí hlavní služby
                var isSuccess = _mainService.CreateReservation(viewModel);
                
                // Pokud vytvoření rezervace proběhlo úspěšně, zobrazí se stránka s potvrzením
                if (isSuccess)
                {
                    return View("/Views/Home/SuccessfulReservation.cshtml", viewModel);
                }
                
                // Pokud došlo k chybě při vytváření rezervace, zobrazí se stránka bez potvrzení
                Console.WriteLine("isSuccess: " + isSuccess);
                return View();
            }
            catch (Exception ex)
            {
                // Výpis chyby v případě výjimky
                Console.WriteLine(ex);
                
                // Přesměrování na stránku s chybou
                return View("Error");
            }
        }
    }
}