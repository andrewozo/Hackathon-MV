using System.Data.SqlTypes;

namespace Hackathon_MV.Server.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Amount { get; set; }

        public Account? Account { get; set; }
    }
}
