namespace NexBank.Domain.DTOs
{
    public class TransactionDTO
    {
        public TransactionDTO()
        {

        }
        public TransactionDTO(string createDate, string description, decimal value)
        {
            CreateDate = createDate;
            Description = description;
            Value = value;

        }
        public string CreateDate { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}