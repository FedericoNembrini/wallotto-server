using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocoLayer.Models
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public long CurrencyId { get; set; }

        public double Balance { get; set; }

        public bool ExcludeFromReport { get; set; }

        public virtual User? User { get; set; }

        public virtual Currency? Currency { get; set; }
    }
}
