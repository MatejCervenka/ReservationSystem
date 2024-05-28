using ReserveSystem.Interfaces;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services;

public class MainService : IMainService
{
    private readonly IPricingService _pricingService;
    private readonly IReservationService _reservationService;
    private readonly IServiceService _serviceService;

    public MainService(IPricingService pricingService, IReservationService reservationService, IServiceService serviceService)
    {
        _pricingService = pricingService;
        _reservationService = reservationService;
        _serviceService = serviceService;
    }

    public IndexPageViewModel GetIndexViewModel()
    {
    
        var pricing = _pricingService.GetPricing();
        var reservations = _reservationService.GetReservations();
        var service = _serviceService.GetService();

        var viewModel = new IndexPageViewModel
        {
            Login = new LoginViewModel
            {
                Id = 1,
                Username = "exampleUser",
                Password = "examplePass",
                CreatedAt = DateTime.Now
            },
            Pricing = pricing,
            Reservation = reservations.FirstOrDefault(),
            Service = service
        };
        return viewModel;
    }
}