using Hackathon_MV.Server.Services.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_MV.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<GetAccountDto>>> GetAllAccounts()
        {
            return Ok(await _accountsService.GetAllAccounts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAccountDto>>> GetSingleAccount(int id)
        {
            return Ok(await _accountsService.GetAccountById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> AddUser(
            AddAccountDto newAccount
        )
        {
            return Ok(await _accountsService.AddAccount(newAccount));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetAccountDto>>>> UpdateAccount(
            UpdateAccountDto updateAccount
        )
        {
            var response = await _accountsService.UpdateAccount(updateAccount);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAccountDto>>> DeleteAccount(int id)
        {
            var response = await _accountsService.DeleteAccount(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
