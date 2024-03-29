﻿namespace Hackathon_MV.Server.DTOS.Account
{
    public class GetAccountDto
    {
        public int Id { get; set; }

        public int AccountNum { get; set; }

        public decimal Balance { get; set; }

        public AccTypeClass Class { get; set; } = AccTypeClass.Checkings;
    }
}
