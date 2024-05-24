using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Interfaces;

namespace ReserveSystem.Controllers;

public class ReservationController : Controller
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public IActionResult Index()
    {
        return View();
    }
}