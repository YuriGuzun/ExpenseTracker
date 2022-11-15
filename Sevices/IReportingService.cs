using ExpenseTrackerApi.Models.Domain;

namespace ExpenseTrackerApi.Services;

public interface IReportingService
{
    public Task<IEnumerable<ReportingRecord>> GetReportAync(DateTime fromDate, DateTime toDate);
}
