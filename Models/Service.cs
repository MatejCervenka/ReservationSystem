namespace ReserveSystem.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Navigační vlastnost pro rezervace
    public ICollection<Reservation> Reservations { get; set; }
}