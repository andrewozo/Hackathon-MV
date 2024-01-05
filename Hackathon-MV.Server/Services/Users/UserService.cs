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

        public async Task<ServiceResponse<List<GetUserDTO>>> AddUser(
            AddUserDTO newUser
        )
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
            var user = _mapper.Map<User>(newUser);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context
                .Users
                .Select(c => _mapper.Map<GetUserDTO>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
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
                    .Select(c => _mapper.Map<GetUserDTO>(c))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
            var dbUsers = await _context.Users.ToListAsync();
            serviceResponse.Data = dbUsers
                .Select(c => _mapper.Map<GetUserDTO>(c))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            var dbUser = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetUserDTO>(dbUser);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> UpdateUser(
            UpdateUserDTO updatedUser
        )
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
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

                serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
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
