using ExpenseTrackerApi.Models.Database;
using ExpenseTrackerApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Repositories;

public class TransactionsRepository : ITransactionsRepository
{
    private readonly DatabaseContext databaseContext;

    public TransactionsRepository(DatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    public async Task<int> CreateTransactionAsync(Transaction transaction)
    {
        this.databaseContext.Transactions.Add(transaction);
        await this.databaseContext.SaveChangesAsync();

        return transaction.Id;
    }

    public async Task<List<Transaction>> GetTransactionsAsync(DateTime fromDate, DateTime toDate)
    {
        var allTransactions = await this.databaseContext
            .Transactions
            .Include(t => t.Category)
            .Where(t => t.Date >= fromDate && t.Date <= toDate)
            .OrderByDescending(t => t.Date)
            .AsNoTracking()
            .ToListAsync();

        return allTransactions;
    }
}
