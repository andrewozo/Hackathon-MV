namespace Hackathon_MV.Server.Services.Users
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();

        Task<ServiceResponse<GetUserDto>> GetUserById(int id);

        Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser);

        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updateUser);

        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
    }
}
