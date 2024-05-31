using AutoMapper;
using ReserveSystem.Interfaces;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services;

public class MainService : IMainService
{
    private readonly IPricingService _pricingService;
    private readonly IReservationService _reservationService;

    public MainService(IPricingService pricingService, IReservationService reservationService)
    {
        _pricingService = pricingService;
        _reservationService = reservationService;
    }

    public IndexPageViewModel GetIndexViewModel()
    {
        var pricingList = _pricingService.GetAll();
        
        var reservationViewModel = new ReservationViewModel
        {
            ServiceList = _reservationService.GetServiceList()
        };

        var viewModel = new IndexPageViewModel
        {
            PricingList = pricingList,
            Reservation = reservationViewModel,
        };
        return viewModel;
    }

    public bool CreateReservation(ReservationViewModel reservationViewModel)
    {
        throw new NotImplementedException();
    }
    
}