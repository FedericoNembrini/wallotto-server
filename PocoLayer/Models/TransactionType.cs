using System.ComponentModel.DataAnnotations;

namespace PocoLayer.Models
{
    public class TransactionType
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
