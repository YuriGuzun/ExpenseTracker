namespace ExpenseTrackerApi.Models.ViewModels;

public class ReportingResponse
{
    public DateTime GenerationDate { get; set; }
    public IEnumerable<ReportingResponseRecord> Records { get; set; }
}
