

namespace Hackathon_MV.Server.Services.Transactions
{
    public interface ITransactionsService
    {
        Task<ServiceResponse<List<GetTransactionDto>>> GetAllTransactions();

        Task<ServiceResponse<GetTransactionDto>> GetTransactionById(int id);

        Task<ServiceResponse<List<GetTransactionDto>>> AddTransaction(AddTransactionDto newTransaction);

        Task<ServiceResponse<GetTransactionDto>> UpdateTransaction(UpdateTransactionDto updateTransaction);

        Task<ServiceResponse<List<GetTransactionDto>>> DeleteTransaction(int id);

    }
}
