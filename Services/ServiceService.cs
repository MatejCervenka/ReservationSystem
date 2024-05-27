using AutoMapper;
using ReserveSystem.Database;
using ReserveSystem.Interfaces;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services;

public class ServiceService : IServiceService
{
    private readonly MyDbContext _dbContext;
    private readonly IMapper _mapper;

    public ServiceService(MyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public List<ServiceViewModel> GetAll()
    {
        var serviceDbModels = _dbContext.Pricings.ToList();
        
        if (serviceDbModels == null || !serviceDbModels.Any())
        {
            return new List<ServiceViewModel>();
        }

        var serviceViewModels = _mapper.Map<List<ServiceViewModel>>(serviceDbModels);

        return serviceViewModels;
    }

    public ServiceViewModel GetById(int id)
    {
        if (id <= 0)
        {
            return null;
        }
        
        var serviceDbModel = _dbContext.Services.Find(id);

        if (serviceDbModel == null)
        {
            return null;
        }

        var serviceViewModel = _mapper.Map<ServiceViewModel>(serviceDbModel);

        return serviceViewModel;
    }

    public ServiceViewModel GetByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return null;
        }
        
        var serviceDbModel = _dbContext.Services.FirstOrDefault(p => p.Name == name);

        if (serviceDbModel == null)
        {
            return null;
        }

        var serviceViewModel = _mapper.Map<ServiceViewModel>(serviceDbModel);

        return serviceViewModel;
    }

    public bool CreateService(ServiceViewModel serviceViewModel)
    {
        if (serviceViewModel == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(serviceViewModel.Name))
        {
            return false; 
        }

        var serviceDbModel = _mapper.Map<Service>(serviceViewModel);

        _dbContext.Services.Add(serviceDbModel);

        return _dbContext.SaveChanges() > 0;
    }
}