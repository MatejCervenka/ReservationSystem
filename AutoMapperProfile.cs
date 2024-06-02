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
        CreateMap<Reservation, ReservationViewModel>();
        CreateMap<Service, ServiceViewModel>();
        CreateMap<Reservation, ReservationListViewModel>()
            .ForMember(dest => dest.ServiceName, src => src.MapFrom(src => src.Service.Name));
    }
}