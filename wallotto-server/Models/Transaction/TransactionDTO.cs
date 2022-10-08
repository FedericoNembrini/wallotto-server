namespace wallotta_server.Models
{
    public class TransactionDTO
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long WalletId { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; } = string.Empty;

        public long CategoryId { get; set; }

        public long TypeId { get; set; }

        public UserDTO? User { get; set; }

        public WalletDTO? Wallet { get; set; }

        //public virtual ICollection<Friend>? Friends { get; set; }
    }
}
