using Microsoft.AspNetCore.Mvc.Rendering;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Interfaces;

public interface IReservationService
{
    List<ReservationListViewModel> GetAll();
    ReservationViewModel GetById(int id);
    ReservationViewModel GetByServiceId(int serviceId);
    ReservationViewModel GetByServiceName(string serviceName);
    ReservationViewModel GetBySurname(string surname);
    bool CreateReservation(ReservationViewModel reservationViewModel);
    List<SelectListItem> GetServiceList();
}