namespace ExpenseTrackerApi.Models.DataTransferObjects;

public class GetTransactionsResponse
{
    public IEnumerable<GetTransactionRecord> Transactions { get; set; }
}
