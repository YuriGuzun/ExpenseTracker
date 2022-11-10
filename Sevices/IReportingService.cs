using ExpenseTrackerApi.Models.Domain;

namespace ExpenseTrackerApi.Models;

public interface IReportingService
{
    public List<ReportingRecord> GetReport(DateTime fromDate, DateTime toDate);
}
