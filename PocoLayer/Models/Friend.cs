using System.ComponentModel.DataAnnotations.Schema;

namespace PocoLayer.Models
{
    public class Friend
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public User? User { get; set; }
    }
}
