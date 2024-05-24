using ReserveSystem.Database;
using ReserveSystem.Interfaces;

namespace ReserveSystem.Services;

public class ServiceService : IServiceService
{
    private readonly MyDbContext _dbContext;

    public ServiceService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void MyMethod()
    {
        throw new NotImplementedException();
    }
}