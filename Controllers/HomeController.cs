using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Interfaces;

namespace ReserveSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMainService _mainService;

        public HomeController(IMainService mainService)
        {
            _mainService = mainService;
        }
        
        public IActionResult Index()
        {
            var viewModel = _mainService.GetIndexViewModel();
            return View(viewModel);
        }
    }
}