namespace ExpenseTrackerApi.Models.ViewModels;

public class ReportingRequest
{
    public DateTime FromDate { get; set; } = DateTime.Now.AddDays(-7);
    public DateTime ToDate { get; set; } = DateTime.Now;
    public List<string> CategoriesToInclude { get; set; }
}
