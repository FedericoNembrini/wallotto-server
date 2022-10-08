
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocoLayer.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public virtual ICollection<Wallet>? Wallets { get; set; }

        public virtual ICollection<Category>? Categories { get; set; }

        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}
