namespace ExpenseTrackerApi.Models.DataTransferObjects;

public class ReportingRequest
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public List<string> CategoriesToInclude { get; set; }
}
