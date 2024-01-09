using AutoMapper;

namespace Hackathon_MV.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();

            CreateMap<AddUserDto, User>();

            CreateMap<Account, GetAccountDto>();

            CreateMap<AddAccountDto, Account>();

            CreateMap<Transaction, GetTransactionDto>();

            CreateMap<AddTransactionDto, Transaction>();
        }
    }
}
