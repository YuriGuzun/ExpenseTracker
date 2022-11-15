using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerApi.Models;
using ExpenseTrackerApi.Models.ViewModels;
using ExpenseTrackerApi.Services;
using ExpenseTrackerApi.Models.Database;

namespace ExpenseTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            this.transactionsService = transactionsService;
        }

        [HttpGet]
        public async Task<ActionResult<GetTransactionsResponse>> GetTransactionsAsync([FromQuery] GetTransactionsRequest request)
        {
            var domainModelTransactions = await this.transactionsService.GetTransactionsAsync(request.FromDate, request.ToDate);
            var response = new GetTransactionsResponse
            {
                Transactions = domainModelTransactions.Select(d =>
                    new GetTransactionRecord
                    {
                        Amount = d.Amount,
                        Date = d.Date,
                        Id = d.Id,
                        Description = d.Description,
                        CategoryName = d.Category.Name
                    })
            };

            return response;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTransaction([FromBody] CreateTransactionRequest request)
        {
            var transaction = new Transaction
            {
                Amount = request.Amount,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Date = request.Date
            };

            return await this.transactionsService.CreateTransactionAsync(transaction);
        }
    }
}
