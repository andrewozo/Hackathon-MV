namespace Hackathon_MV.Server.DTOS.User
{
    public class AddUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public byte[] PasswordHash { get; set; } = new byte[0];

        public byte[] PasswordSalt { get; set; } = new byte[0];

        public string? Email { get; set; }
    }
}
