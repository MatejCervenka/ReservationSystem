using ReserveSystem.ViewModels;

namespace ReserveSystem.Interfaces;

public interface IAdminService
{
    ReservationsListViewModel GetReservationsListViewModel();

}