using ReserveSystem.ViewModels;

namespace ReserveSystem.Interfaces;

public interface ILoginService
{
    bool IsValid(string username, string password);
    List<LoginViewModel> GetAll();
    LoginViewModel GetById(int id);
    LoginViewModel GetByName(string name);
    bool CreateLogin(LoginViewModel loginViewModel);
}