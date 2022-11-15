using ExpenseTrackerApi.Models.Database;
using ExpenseTrackerApi.Models.Domain;
using ExpenseTrackerApi.Repositories;

namespace ExpenseTrackerApi.Services.Implementation;

public class ReportingService : IReportingService
{
    private readonly ITransactionsRepository transactionsRepository;

    public ReportingService(ITransactionsRepository transactionsRepository)
    {
        this.transactionsRepository = transactionsRepository;
    }

    public async Task<IEnumerable<ReportingRecord>> GetReportAync(DateTime fromDate, DateTime toDate)
    {
        var transaction = await this.transactionsRepository.GetTransactionsAsync(fromDate, toDate);
        double totalSum = transaction.Sum(t => t.Amount);

        return transaction.GroupBy(
            t => t.Category.Name,
            t => t.Amount,
            (categoryName, ammounts) => new ReportingRecord { CategoryName = categoryName, Percent = ammounts.Sum() / totalSum * 100 });
    }
}
