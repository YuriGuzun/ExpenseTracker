namespace ExpenseTrackerApi.Models.ViewModels;

public class CreateTransactionRequest
{
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
}
