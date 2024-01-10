
using System.Security.Claims;
using AutoMapper;
using Hackathon_MV.Server.Data;

namespace Hackathon_MV.Server.Services.Accounts
{
    public class AccountsService : IAccountsService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountsService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        
        public async Task<ServiceResponse<List<GetAccountDto>>> AddAccount(AddAccountDto newAccount, int userId)
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDto>>();
            var account = _mapper.Map<Account>(newAccount);
            account.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context
                .Accounts
                .Select(c => _mapper.Map<GetAccountDto>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAccountDto>>> DeleteAccount(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDto>>();
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
                    .Select(c => _mapper.Map<GetAccountDto>(c))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAccountDto>> GetAccountById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAccountDto>();

            var dbAccount = await _context.Accounts.FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetAccountDto>(dbAccount);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAccountDto>>> GetAllAccounts(int userId)
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDto>>();
            var dbAccounts = await _context.Accounts.Where(acc => acc.User!.Id == userId).ToListAsync();
            serviceResponse.Data = dbAccounts
                .Select(c => _mapper.Map<GetAccountDto>(c))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto updateAccount)
        {
            var serviceResponse = new ServiceResponse<GetAccountDto>();
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

                serviceResponse.Data = _mapper.Map<GetAccountDto>(account);
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
