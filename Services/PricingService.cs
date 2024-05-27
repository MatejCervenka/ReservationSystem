using AutoMapper;
using ReserveSystem.Database;
using ReserveSystem.Interfaces;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services;

public class PricingService : IPricingService
{
    private readonly MyDbContext _dbContext;
    private readonly IMapper _mapper;

    public PricingService(MyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<PricingViewModel> GetAll()
    {
        var pricingDbModels = _dbContext.Pricings.ToList();
        
        if (pricingDbModels == null || !pricingDbModels.Any())
        {
            return new List<PricingViewModel>();
        }

        var pricingViewModels = _mapper.Map<List<PricingViewModel>>(pricingDbModels);

        return pricingViewModels;
    }

    public PricingViewModel GetById(int id)
    {
        if (id <= 0)
        {
            return null;
        }
        
        var pricingDbModel = _dbContext.Pricings.Find(id);

        if (pricingDbModel == null)
        {
            return null;
        }

        var pricingViewModel = _mapper.Map<PricingViewModel>(pricingDbModel);

        return pricingViewModel;
    }

    public PricingViewModel GetByTitle(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            return null;
        }
        
        var pricingDbModel = _dbContext.Pricings.FirstOrDefault(p => p.Title == title);

        if (pricingDbModel == null)
        {
            return null;
        }

        var pricingViewModel = _mapper.Map<PricingViewModel>(pricingDbModel);

        return pricingViewModel;
    }

    public bool CreatePricing(PricingViewModel pricingViewModel)
    {
        if (pricingViewModel == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(pricingViewModel.Title))
        {
            return false; 
        }
        
        if (string.IsNullOrEmpty(pricingViewModel.Description))
        {
            return false; 
        }
        
        if (decimal.IsNegative(pricingViewModel.Amount))
        {
            return false; 
        }
        
        if (decimal.IsNegative(pricingViewModel.SaleAmount))
        {
            return false; 
        }

        var pricingDbModel = _mapper.Map<Pricing>(pricingViewModel);

        _dbContext.Pricings.Add(pricingDbModel);

        return _dbContext.SaveChanges() > 0;
    }
}