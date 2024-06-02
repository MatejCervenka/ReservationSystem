using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    public List<SelectListItem> ServiceList { get; set; }
    
}

public class ReservationListViewModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
    
    public string ServiceName { get; set; }
    
    public DateTime CreatedAt { get; set; }
}

public class ReservationsListViewModel
{
    public List<ReservationListViewModel> ReservationList { get; set; }
}