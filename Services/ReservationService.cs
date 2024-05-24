using ReserveSystem.Interfaces;

namespace ReserveSystem.Services;

public class ReservationService : IReservationService 
{
    private readonly MyDbContext _dbContext;

    public ReservationService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void MyMethod()
    {
        throw new NotImplementedException();
    }
}