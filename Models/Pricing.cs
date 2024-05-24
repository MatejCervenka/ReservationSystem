using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models;

public class Pricing : Entity
{
    [Required] 
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal SaleAmount { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }
    
    [Required]
    [Column(TypeName = "char(5)")]
    public char Currency { get; set; }
}