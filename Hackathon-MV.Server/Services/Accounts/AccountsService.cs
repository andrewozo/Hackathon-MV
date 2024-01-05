
using AutoMapper;
using Hackathon_MV.Server.Data;

namespace Hackathon_MV.Server.Services.Accounts
{
    public class AccountsService : IAccountsService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AccountsService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetAccountDTO>>> AddAccount(AddAccountDTO newAccount)
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDTO>>();
            var account = _mapper.Map<Account>(newAccount);
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context
                .Accounts
                .Select(c => _mapper.Map<GetAccountDTO>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAccountDTO>>> DeleteAccount(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDTO>>();
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(c => c.Id == id);
                if (account == null)
                {
                    throw new Exception($"Account with ID {id} not found");
                }

                _context.Accounts.Remove(account);

                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context
                    .Accounts
                    .Select(c => _mapper.Map<GetAccountDTO>(c))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAccountDTO>> GetAccountById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAccountDTO>();

            var dbAccount = await _context.Accounts.FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetAccountDTO>(dbAccount);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAccountDTO>>> GetAllAccounts()
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDTO>>();
            var dbAccounts = await _context.Users.ToListAsync();
            serviceResponse.Data = dbAccounts
                .Select(c => _mapper.Map<GetAccountDTO>(c))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAccountDTO>> UpdateAccount(UpdateAccountDTO updateAccount)
        {
            var serviceResponse = new ServiceResponse<GetAccountDTO>();
            try
            {
                var account = await _context
                    .Accounts
                    .FirstOrDefaultAsync(c => c.Id == updateAccount.Id);
                if (account == null)
                {
                    throw new Exception($"Account with ID {updateAccount.Id} not found");
                }

                account.AccountNum = updateAccount.AccountNum;
                account.Balance = updateAccount.Balance;
                account.Class = updateAccount.Class;


                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetAccountDTO>(account);
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
