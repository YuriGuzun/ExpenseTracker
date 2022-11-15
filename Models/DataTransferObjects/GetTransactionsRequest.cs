namespace ExpenseTrackerApi.Models.DataTransferObjects;

public class GetTransactionsRequest
{
    public DateTime FromDate { get; set; } = DateTime.Now.AddDays(-7);
    public DateTime ToDate { get; set; } = DateTime.Now;
    public List<string> CategoriesToInclude { get; set; }
}
