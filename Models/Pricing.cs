namespace ReserveSystem.Models;

public class Pricing
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal SaleAmount { get; set; }
    public decimal Amount { get; set; }
    public char Currency { get; set; }
}