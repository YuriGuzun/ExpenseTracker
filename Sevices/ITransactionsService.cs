using ExpenseTrackerApi.Models.Database;

namespace ExpenseTrackerApi.Services;

public interface ITransactionsService
{
    public Task<int> CreateTransactionAsync(Transaction transaction);
    public Task<List<Transaction>> GetTransactionsAsync(DateTime fromDate, DateTime toDate);
}
