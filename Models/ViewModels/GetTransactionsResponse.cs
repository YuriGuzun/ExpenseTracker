namespace ExpenseTrackerApi.Models.ViewModels;

public class GetTransactionsResponse
{
    public IEnumerable<GetTransactionRecord> Transactions { get; set; }
}
