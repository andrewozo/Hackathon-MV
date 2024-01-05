namespace Hackathon_MV.Server.DTOS.User
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }

        public string? Email { get; set; }
    }
}
