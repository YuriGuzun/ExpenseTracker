namespace ExpenseTrackerApi.Models.DataTransferObjects;

public class ReportingResponse
{
    public DateTime GenerationDate { get; set; }
    public IEnumerable<ReportingResponseRecord> Records { get; set; }
}
