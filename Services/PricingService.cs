using ReserveSystem.Database;
using ReserveSystem.Interfaces;

namespace ReserveSystem.Services;

public class PricingService : IPricingService
{
    private readonly MyDbContext _dbContext;

    public PricingService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void MyMethod()
    {
        throw new NotImplementedException();
    }
}