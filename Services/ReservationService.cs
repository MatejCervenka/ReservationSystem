using AutoMapper;
using ReserveSystem.Database;
using ReserveSystem.Interfaces;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services;

public class ReservationService : IReservationService 
{
    private readonly MyDbContext _dbContext;
    private readonly IMapper _mapper;

    public ReservationService(MyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<ReservationViewModel> GetAll()
    {
        var reservationDbModels = _dbContext.Pricings.ToList();
        
        if (reservationDbModels == null || !reservationDbModels.Any())
        {
            return new List<ReservationViewModel>();
        }

        var reservationViewModels = _mapper.Map<List<ReservationViewModel>>(reservationDbModels);

        return reservationViewModels;
    }

    public ReservationViewModel GetById(int id)
    {
        if (id <= 0)
        {
            return null;
        }
        
        var reservationDbModel = _dbContext.Reservations.Find(id);

        if (reservationDbModel == null)
        {
            return null;
        }

        var reservationViewModel = _mapper.Map<ReservationViewModel>(reservationDbModel);

        return reservationViewModel;
    }

    public ReservationViewModel GetByServiceId(int serviceId)
    {
        if (serviceId <= 0)
        {
            return null;
        }

        // Najde rezervaci podle ServiceId
        var reservationDbModel = _dbContext.Reservations.FirstOrDefault(r => r.ServiceId == serviceId);

        if (reservationDbModel == null)
        {
            return null;
        }

        // Namapuje entitu Reservation na ReservationViewModel pomocí AutoMapperu
        var reservationViewModel = _mapper.Map<ReservationViewModel>(reservationDbModel);

        return reservationViewModel;
    }

    public ReservationViewModel GetByServiceName(string serviceName)
    {
        if (string.IsNullOrEmpty(serviceName))
        {
            return null;
        }

        // Najde službu podle jména
        var serviceDbModel = _dbContext.Services.FirstOrDefault(s => s.Name == serviceName);

        if (serviceDbModel == null)
        {
            return null;
        }

        // Najde rezervaci podle ServiceId
        var reservationDbModel = _dbContext.Reservations.FirstOrDefault(r => r.ServiceId == serviceDbModel.Id);

        if (reservationDbModel == null)
        {
            return null;
        }

        // Namapuje entitu Reservation na ReservationViewModel pomocí AutoMapperu
        var reservationViewModel = _mapper.Map<ReservationViewModel>(reservationDbModel);

        return reservationViewModel;
    }

    public ReservationViewModel GetBySurname(string surname)
    {
        if (string.IsNullOrEmpty(surname))
        {
            return null;
        }
        
        var reservationDbModel = _dbContext.Reservations.FirstOrDefault(p => p.Surname == surname);

        if (reservationDbModel == null)
        {
            return null;
        }

        var reservationViewModel = _mapper.Map<ReservationViewModel>(reservationDbModel);

        return reservationViewModel;
    }

    public bool CreateReservation(ReservationViewModel reservationViewModel)
    {
        if (reservationViewModel == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(reservationViewModel.Name))
        {
            return false; 
        }
        
        if (string.IsNullOrEmpty(reservationViewModel.Surname))
        {
            return false; 
        }
        
        if (string.IsNullOrEmpty(reservationViewModel.Phone))
        {
            return false; 
        }
        
        if (string.IsNullOrEmpty(reservationViewModel.Email))
        {
            return false; 
        }
        
        var reservationDbModel = _mapper.Map<Reservation>(reservationViewModel);

        _dbContext.Reservations.Add(reservationDbModel);

        return _dbContext.SaveChanges() > 0;
    }
    
    public List<ReservationViewModel> GetReservations()
    {
        return _dbContext.Reservations
            .Select(r => new ReservationViewModel
            {
                Id = r.Id,
                ServiceId = r.ServiceId,
                Name = r.Name,
                Surname = r.Surname,
                Phone = r.Phone,
                Email = r.Email,
                CreatedAt = r.CreatedAt
            })
            .ToList();
    }
}