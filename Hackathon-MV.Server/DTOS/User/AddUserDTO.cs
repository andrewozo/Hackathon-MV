﻿namespace Hackathon_MV.Server.DTOS.User
{
    public class AddUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }

        public string? Email { get; set; }
    }
}
