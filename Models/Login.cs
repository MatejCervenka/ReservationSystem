using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;

public class Login : Entity
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public DateTime CreatedAt { get; set; }
}