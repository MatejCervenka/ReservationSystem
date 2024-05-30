namespace ReserveSystem.ViewModels;

public class IndexPageViewModel
{
    public List<PricingViewModel> PricingList { get; set; }
    public ReservationViewModel Reservation { get; set; }
    
    public List<ServiceViewModel> ServiceList { get; set; }
}