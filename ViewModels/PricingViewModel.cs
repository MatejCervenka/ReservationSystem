using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.ViewModels;

public class PricingViewModel
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public decimal SaleAmount { get; set; }

    public decimal Amount { get; set; }
    
    public char Currency { get; set; }
}