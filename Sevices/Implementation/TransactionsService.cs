using ExpenseTrackerApi.Models.Database;
using ExpenseTrackerApi.Repositories;

namespace ExpenseTrackerApi.Services.Implementation;

public class TransactionsService : ITransactionsService
{
    private readonly ITransactionsRepository transactionsRepository;

    public TransactionsService(ITransactionsRepository transactionsRepository)
    {
        this.transactionsRepository = transactionsRepository;
    }

    public async Task<int> CreateTransactionAsync(Transaction transaction)
    {
        return await this.transactionsRepository.CreateTransactionAsync(transaction);
    }

    public async Task<List<Transaction>> GetTransactionsAsync(DateTime fromDate, DateTime toDate)
    {
        return await this.transactionsRepository.GetTransactionsAsync(fromDate, toDate);
    }

    public Task<Transaction> GetTransactionsAsync(int id)
    {
        return this.transactionsRepository.GetTransactionAsync(id);
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        await this.transactionsRepository.UpdateTransactionAsync(transaction);
    }
}
