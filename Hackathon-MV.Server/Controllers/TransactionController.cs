using Hackathon_MV.Server.Services.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_MV.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<GetTransactionDto>>> GetAllTransactions(int accId)
        {
            return Ok(await _transactionsService.GetAllTransactions());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTransactionDto>>> GetSingleTransaction(int id)
        {
            return Ok(await _transactionsService.GetTransactionById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> AddTransaction(
            AddTransactionDto newTransaction
        )
        {
            return Ok(await _transactionsService.AddTransaction(newTransaction));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> UpdateTransaction(
            UpdateTransactionDto updateTransaction
        )
        {
            var response = await _transactionsService.UpdateTransaction(updateTransaction);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTransactionDto>>> DeleteTransaction(int id)
        {
            var response = await _transactionsService.DeleteTransaction(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}
