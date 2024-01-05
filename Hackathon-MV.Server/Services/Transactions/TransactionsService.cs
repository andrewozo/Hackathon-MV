
using AutoMapper;
using Hackathon_MV.Server.Data;
using Hackathon_MV.Server.Migrations;
using System.Security.Principal;

namespace Hackathon_MV.Server.Services.Transactions
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TransactionsService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetTransactionDto>>> AddTransaction(AddTransactionDto newTransaction)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            var transaction = _mapper.Map<Transaction>(newTransaction);
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context
                .Transactions
                .Select(c => _mapper.Map<GetTransactionDto>(c))
                .ToListAsync();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> DeleteTransaction(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            try
            {
                var transaction = await _context.Transactions.FirstOrDefaultAsync(c => c.Id == id);
                if (transaction == null)
                {
                    throw new Exception($"Transaction with ID {id} not found");
                }

                _context.Transactions.Remove(transaction);

                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context
                    .Transactions
                    .Select(c => _mapper.Map<GetTransactionDto>(c))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> GetAllTransactions()
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            var dbTransactions = await _context.Transactions.ToListAsync();
            serviceResponse.Data = dbTransactions
                .Select(c => _mapper.Map<GetTransactionDto>(c))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransactionDto>> GetTransactionById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTransactionDto>();

            var dbTransaction = await _context.Transactions.FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetTransactionDto>(dbTransaction);

            return serviceResponse;

        }

        public async Task<ServiceResponse<GetTransactionDto>> UpdateTransaction(UpdateTransactionDto updateTransaction)
        {
            var serviceResponse = new ServiceResponse<GetTransactionDto>();
            try
            {
                var transaction = await _context
                .Transactions
                    .FirstOrDefaultAsync(c => c.Id == updateTransaction.Id);
                if (transaction == null)
                {
                    throw new Exception($"Transaction with ID {updateTransaction.Id} not found");
                }

                transaction.Name = updateTransaction.Name;
                transaction.Amount = updateTransaction.Amount;
                


                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetTransactionDto>(transaction);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
