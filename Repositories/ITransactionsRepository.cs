using ExpenseTrackerApi.Models.Database;

namespace ExpenseTrackerApi.Repositories;

public interface ITransactionsRepository
{
    Task<int> CreateTransactionAsync(Transaction transaction);
    public Task<List<Transaction>> GetTransactionsAsync(DateTime fromDate, DateTime toDate);
}
