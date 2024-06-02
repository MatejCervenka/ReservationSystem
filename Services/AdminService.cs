using ReserveSystem.Interfaces;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services;

public class AdminService : IAdminService
{
    private readonly IReservationService _reservationService;

    public AdminService(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public ReservationsListViewModel GetReservationsListViewModel()
    {
        var reservationList = _reservationService.GetAll();

        var viewModel = new ReservationsListViewModel
        {
            ReservationList = reservationList
        };
        return viewModel;
    }
}