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

    public async Task<List<ReportingRecord>> GetReportAync(DateTime fromDate, DateTime toDate)
    {
        var transaction = await this.transactionsRepository.GetTransactionsAsync(fromDate, toDate);

        // TODO: Do the actual calculations
        return new List<ReportingRecord> { new ReportingRecord { CategoryName = "Food", Percent = 100 }};
    }
}
