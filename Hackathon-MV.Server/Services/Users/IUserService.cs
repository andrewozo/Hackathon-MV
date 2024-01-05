namespace Hackathon_MV.Server.Services.Users
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers();

        Task<ServiceResponse<GetUserDTO>> GetUserById(int id);

        Task<ServiceResponse<List<GetUserDTO>>> AddUser(AddUserDTO newUser);

        Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updateUser);

        Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id);
    }
}
