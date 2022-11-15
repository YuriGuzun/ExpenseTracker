using ExpenseTrackerApi.Models.Domain;

namespace ExpenseTrackerApi.Services;

public interface IReportingService
{
    public Task<List<ReportingRecord>> GetReportAync(DateTime fromDate, DateTime toDate);
}
