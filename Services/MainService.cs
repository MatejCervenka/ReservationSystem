using ReserveSystem.Database;
using ReserveSystem.Interfaces;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services;

public class MainService : IMainService
{
    private readonly IPricingService _pricingService;
    private readonly IReservationService _reservationService;
    private readonly MyDbContext _dbContext;

    public MainService(IPricingService pricingService, IReservationService reservationService, MyDbContext dbContext)
    {
        _pricingService = pricingService;
        _reservationService = reservationService;
        _dbContext = dbContext;
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
        try
        {
            var reservation = new Reservation
            {
                Name = reservationViewModel.Name,
                Surname = reservationViewModel.Surname,
                Phone = reservationViewModel.Phone,
                Email = reservationViewModel.Email,
                ServiceId = reservationViewModel.ServiceId,
                CreatedAt = DateTime.Now
            };

            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
}