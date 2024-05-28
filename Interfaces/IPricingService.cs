using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Interfaces;

public interface IPricingService
{
    List<PricingViewModel> GetAll();
    PricingViewModel GetById(int id);
    PricingViewModel GetByTitle(string title);
    bool CreatePricing(PricingViewModel pricingViewModel);
    PricingViewModel? GetPricing();
}