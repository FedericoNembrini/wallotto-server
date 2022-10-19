namespace wallotto_server.Models
{
    public class WalletDTO
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public long CurrencyId { get; set; }

        public double Balance { get; set; }

        public bool ExcludeFromReport { get; set; }

        public UserDTO? User { get; set; }

        //public virtual Currency? Currency { get; set; }
    }
}
