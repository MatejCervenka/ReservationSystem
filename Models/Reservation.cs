using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models;

public class Reservation
{
    public int Id { get; set; }
    [ForeignKey("Service")]
    public int ServiceId { get; set; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Service Service { get; set; }
}