using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models;

public class Reservation : Entity
{
    [Required]
    [ForeignKey("Service")]
    public int ServiceId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    [Required]
    public string Phone { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    public Service Service { get; set; }
    
    public Pricing Pricing { get; set; }
}