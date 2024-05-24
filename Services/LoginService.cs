using ReserveSystem.Interfaces;

namespace ReserveSystem.Services;

public class LoginService : ILoginService
{
    private readonly MyDbContext _dbContext;

    public LoginService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void MyMethod()
    {
        throw new NotImplementedException();
    }
}