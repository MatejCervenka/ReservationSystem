using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.ViewModels;

public class LoginViewModel
{
    public int Id { get; set; }
    
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public DateTime CreatedAt { get; set; }
}