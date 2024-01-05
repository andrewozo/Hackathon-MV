using AutoMapper;
using Hackathon_MV.Server.Data;
using Hackathon_MV.Server.DTOS.User;

namespace Hackathon_MV.Server.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(
            AddUserDto newUser
        )
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var user = _mapper.Map<User>(newUser);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context
                .Users
                .Select(c => _mapper.Map<GetUserDto>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
                if (user == null)
                {
                    throw new Exception($"User with ID {id} not found");
                }

                _context.Users.Remove(user);

                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context
                    .Users
                    .Select(c => _mapper.Map<GetUserDto>(c))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var dbUsers = await _context.Users.ToListAsync();
            serviceResponse.Data = dbUsers
                .Select(c => _mapper.Map<GetUserDto>(c))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            var dbUser = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetUserDto>(dbUser);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(
            UpdateUserDto updatedUser
        )
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = await _context
                    .Users
                    .FirstOrDefaultAsync(c => c.Id == updatedUser.Id);
                if (user == null)
                {
                    throw new Exception($"User with ID {updatedUser.Id} not found");
                }

                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
               

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
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
