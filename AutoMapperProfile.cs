using AutoMapper;
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
        CreateMap<Reservation, ReservationViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Service.Name));
        CreateMap<Service, ServiceViewModel>();
    }
}