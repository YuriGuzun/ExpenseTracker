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
                Transactions = domainModelTransactions.Select(d => GetTransactionRecord(d))
            };

            return response;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTransaction([FromBody] UpsertTransactionRequest request)
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

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateTransaction([FromBody] UpsertTransactionRequest request, int id)
        {
            var transaction = await this.transactionsService.GetTransactionsAsync(id);
            if (transaction is null)
            {
                return this.NotFound();
            }

            transaction.Amount = request.Amount;
            transaction.Description = request.Description;
            transaction.CategoryId = request.CategoryId;
            transaction.Date = request.Date;
            transaction.Id = id;

            await this.transactionsService.UpdateTransactionAsync(transaction);

            return this.NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTransactionRecord>> GetTransaction(int id)
        {
            var transaction = await this.transactionsService.GetTransactionsAsync(id);

            if (transaction is null)
            {
                return this.NotFound();
            }

            return GetTransactionRecord(transaction);
        }

        private static GetTransactionRecord GetTransactionRecord(Transaction transaction)
        {
            return new GetTransactionRecord
            {
                Amount = transaction.Amount,
                Date = transaction.Date,
                Id = transaction.Id,
                Description = transaction.Description,
                CategoryName = transaction.Category.Name,
                CategoryId = transaction.CategoryId
            };
        }
    }
}
