namespace Hackathon_MV.Server.Services.Accounts;

public interface IAccountsService
{
    Task<ServiceResponse<List<GetAccountDto>>> GetAllAccounts(int userId);

    Task<ServiceResponse<GetAccountDto>> GetAccountById(int id);

    Task<ServiceResponse<List<GetAccountDto>>> AddAccount(AddAccountDto newAccount);

    Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto updateAccount);

    Task<ServiceResponse<List<GetAccountDto>>> DeleteAccount(int id);

}