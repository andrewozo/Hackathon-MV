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
        public async Task<ActionResult<ServiceResponse<GetAccountDTO>>> GetAllAccounts()
        {
            return Ok(await _accountsService.GetAllAccounts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAccountDTO>>> GetSingleAccount(int id)
        {
            return Ok(await _accountsService.GetAccountById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetUserDTO>>>> AddUser(
            AddAccountDTO newAccount
        )
        {
            return Ok(await _accountsService.AddAccount(newAccount));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetAccountDTO>>>> UpdateAccount(
            UpdateAccountDTO updateAccount
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
        public async Task<ActionResult<ServiceResponse<GetAccountDTO>>> DeleteAccount(int id)
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
