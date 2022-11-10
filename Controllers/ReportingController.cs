using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerApi.Models;
using ExpenseTrackerApi.Models.DataTransferObjects;

namespace ExpenseTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly IReportingService reportingService;

        public ReportingController(IReportingService reportingService)
        {
            this.reportingService = reportingService;
        }

        [HttpGet]
        public async Task<ActionResult<ReportingResponse>> GetReport([FromQuery] ReportingRequest request)
        {
            if (request.FromDate > DateTime.Now)
            {
                return BadRequest("From date should be in the past");
            }

            var records = this.reportingService.GetReport(request.FromDate, request.ToDate);
            var response = new ReportingResponse
            {
                GenerationDate = DateTime.Now,
                Records = records.Select(
                r => new ReportingResponseRecord { CategoryName = r.CategoryName, Percent = r.Percent })
            };

            return response;
        }
    }
}
