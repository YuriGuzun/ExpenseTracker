using ExpenseTrackerApi.Models.Domain;

namespace ExpenseTrackerApi.Models.Database;

public class ReportingService : IReportingService
{
    private readonly DatabaseContext databaseContext;

    public ReportingService(DatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    public List<ReportingRecord> GetReport(DateTime fromDate, DateTime toDate)
    {
        return new List<ReportingRecord>
        {
            new ReportingRecord { CategoryName = "Food", Percent = 50 },
            new ReportingRecord { CategoryName = "Entertaiment", Percent = 50 }
        };
    }
}
