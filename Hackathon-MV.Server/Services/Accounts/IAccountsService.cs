namespace Hackathon_MV.Server.Services.Accounts;

public interface IAccountsService
{
    Task<ServiceResponse<List<GetAccountDTO>>> GetAllAccounts();

    Task<ServiceResponse<GetAccountDTO>> GetAccountById(int id);

    Task<ServiceResponse<List<GetAccountDTO>>> AddAccount(AddAccountDTO newAccount);

    Task<ServiceResponse<GetAccountDTO>> UpdateAccount(UpdateAccountDTO updateAccount);

    Task<ServiceResponse<List<GetAccountDTO>>> DeleteAccount(int id);

}