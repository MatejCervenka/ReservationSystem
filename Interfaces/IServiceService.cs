using ReserveSystem.ViewModels;

namespace ReserveSystem.Interfaces;

public interface IServiceService
{
    List<ServiceViewModel> GetAll();
    ServiceViewModel GetById(int id);
    ServiceViewModel GetByName(string name);
    bool CreateService(ServiceViewModel serviceViewModel);
    
}