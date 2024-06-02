using ReserveSystem.Database;
using ReserveSystem.Interfaces;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services
{
    // Hlavní služba aplikace, implementující rozhraní IMainService
    public class MainService : IMainService
    {
        private readonly IPricingService _pricingService;
        private readonly IReservationService _reservationService;
        private readonly MyDbContext _dbContext;

        // Konstruktor služby, který injektuje závislosti
        public MainService(IPricingService pricingService, IReservationService reservationService, MyDbContext dbContext)
        {
            _pricingService = pricingService;
            _reservationService = reservationService;
            _dbContext = dbContext;
        }

        // Metoda pro získání viewModelu pro úvodní stránku
        public IndexPageViewModel GetIndexViewModel()
        {
            // Získání seznamu cen pomocí PricingService
            var pricingList = _pricingService.GetAll();
            
            // Vytvoření viewModelu pro rezervaci
            var reservationViewModel = new ReservationViewModel
            {
                ServiceList = _reservationService.GetServiceList()
            };

            // Vytvoření hlavního viewModelu pro úvodní stránku
            var viewModel = new IndexPageViewModel
            {
                PricingList = pricingList,
                Reservation = reservationViewModel,
            };
            return viewModel;
        }

        // Metoda pro vytvoření nové rezervace
        public bool CreateReservation(ReservationViewModel reservationViewModel)
        {
            try
            {
                // Vytvoření nové rezervace z ReservationViewModel
                var reservation = new Reservation
                {
                    Name = reservationViewModel.Name,
                    Surname = reservationViewModel.Surname,
                    Phone = reservationViewModel.Phone,
                    Email = reservationViewModel.Email,
                    ServiceId = reservationViewModel.ServiceId,
                    CreatedAt = DateTime.Now
                };

                // Přidání rezervace do databáze a uložení změn
                _dbContext.Reservations.Add(reservation);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Výpis chyby při neúspěšném vytváření rezervace
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
