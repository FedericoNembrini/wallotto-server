using System.ComponentModel.DataAnnotations;

namespace PocoLayer.Models
{
    public class Transaction
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }

        public long WalletId { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; } = string.Empty;

        public long CategoryId { get; set; }

        public long TypeId { get; set; }

        public virtual User? User { get; set; }

        public virtual Wallet? Wallet { get; set; }

        public virtual ICollection<Friend>? Friends { get; set; }
    }
}
