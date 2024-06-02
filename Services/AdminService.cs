using ReserveSystem.Interfaces;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services
{
    // Služba pro administrátory, implementující rozhraní IAdminService
    public class AdminService : IAdminService
    {
        private readonly IReservationService _reservationService;

        // Konstruktor, který injektuje IReservationService
        public AdminService(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // Metoda pro získání viewModelu seznamu rezervací
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
}