using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.ViewModels;

public class ServiceViewModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    // Navigační vlastnost pro rezervace
    public ICollection<ReservationViewModel> Reservations { get; set; }
}