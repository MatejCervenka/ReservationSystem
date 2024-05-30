using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Login, LoginViewModel>();
        CreateMap<Pricing, PricingViewModel>();
        CreateMap<Reservation, ReservationViewModel>();
        CreateMap<ServiceViewModel, SelectListItem>()
            .ForMember(x => x.Text, y => y.MapFrom(src => src.Name));
        CreateMap<Reservation, ReservationViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Service.Name));
        CreateMap<Service, ServiceViewModel>();
    }
}