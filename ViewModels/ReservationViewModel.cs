using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.ViewModels;

public class ReservationViewModel
{
    public int Id { get; set; }
    
    public int ServiceId { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public ServiceViewModel ServiceViewModel { get; set; }
}