using System.Security.Cryptography;

namespace Hackathon_MV.Server
{
    public class User
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }

        private string Password { get; set; }

        public string? Email { get; set; }

        public User(string firstName, string lastName, string password, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
        }



    }
}
