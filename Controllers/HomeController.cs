using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Interfaces;
using ReserveSystem.ViewModels;

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

        [HttpPost]
        [Route("/create-reservation")]
        public IActionResult CreateReservation(ReservationViewModel viewModel)
        {
            try
            {
                var isSuccess = _mainService.CreateReservation(viewModel);
                if (isSuccess)
                {
                    return View("/Views/Home/SuccessfulReservation.cshtml", viewModel);
                }
                Console.WriteLine("isSuccess: " + isSuccess);
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
                return View("Error");
            }
        }
    }
}