using System.Data.SqlTypes;

namespace Hackathon_MV.Server.Models
{
    public class Account
    {
        public int Id { get; set; }

        public int AccountNum { get; set; }

        public decimal Balance { get; set; }

        public AccTypeClass Class { get; set; } = AccTypeClass.Checkings;


    }
}
