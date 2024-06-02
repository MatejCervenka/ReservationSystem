using ReserveSystem.ViewModels;

namespace ReserveSystem.Interfaces;

public interface IMainService
{
    IndexPageViewModel GetIndexViewModel();
    
    bool CreateReservation(ReservationViewModel reservationViewModel);
}