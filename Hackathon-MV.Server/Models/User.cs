using System.Security.Cryptography;

namespace Hackathon_MV.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public byte[] PasswordHash { get; set; } = new byte[0];

        public byte[] PasswordSalt { get; set; } = new byte[0];

        public string? Email { get; set; }

        public List<Account>? Accounts { get; set; }

        



    }
}
