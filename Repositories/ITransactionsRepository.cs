using ExpenseTrackerApi.Models.Database;

namespace ExpenseTrackerApi.Repositories;

public interface ITransactionsRepository
{
    Task<int> CreateTransactionAsync(Transaction transaction);
    Task<Transaction> GetTransactionAsync(int id);
    public Task<List<Transaction>> GetTransactionsAsync(DateTime fromDate, DateTime toDate);
    Task UpdateTransactionAsync(Transaction transaction);
}
