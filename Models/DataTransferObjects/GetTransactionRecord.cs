namespace ExpenseTrackerApi.Models.DataTransferObjects;

public class GetTransactionRecord
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
}
