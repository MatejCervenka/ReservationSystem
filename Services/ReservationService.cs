﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

    public List<ReservationListViewModel> GetAll()
    {
        var reservation = _dbContext.Reservations.Include(x => x.Service).ToList();
        var result = _mapper.Map<List<ReservationListViewModel>>(reservation);
        return result;
    }
    
    
    public ReservationViewModel GetById(int id)
    {
        if (id == 0)
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

    public List<SelectListItem> GetServiceList()
    {
        return _dbContext.Services.Select(service => new SelectListItem
        {
            Value = service.Id.ToString(),
            Text = service.Name
        }).ToList();
    }
}