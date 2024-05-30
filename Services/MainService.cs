using AutoMapper;
using ReserveSystem.Interfaces;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services;

public class MainService : IMainService
{
    private readonly IPricingService _pricingService;

    public MainService(IPricingService pricingService)
    {
        _pricingService = pricingService;
    }

    public IndexPageViewModel GetIndexViewModel()
    {
        var pricingList = _pricingService.GetAll();

        var viewModel = new IndexPageViewModel
        {
            PricingList = pricingList,
        };
        return viewModel;
    }
}