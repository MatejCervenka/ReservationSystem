using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Database;
using ReserveSystem.Interfaces;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;
using ReserveSystem.Services; // Make sure you have this service

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