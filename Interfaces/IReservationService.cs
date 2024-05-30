using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Interfaces;

public interface IReservationService
{
    List<ReservationViewModel> GetAll();
    ReservationViewModel GetById(int id);
    ReservationViewModel GetByServiceId(int serviceId);
    ReservationViewModel GetByServiceName(string serviceName);
    ReservationViewModel GetBySurname(string surname);
    bool CreateReservation(ReservationViewModel reservationViewModel);
}