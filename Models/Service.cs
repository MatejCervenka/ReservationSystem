using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;

public class Service : Entity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    // Navigační vlastnost pro rezervace
    public ICollection<Reservation> Reservations { get; set; }
}