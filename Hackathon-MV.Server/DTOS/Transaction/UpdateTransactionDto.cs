namespace Hackathon_MV.Server.DTOS.Transaction
{
    public class UpdateTransactionDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Amount { get; set; }
    }
}
