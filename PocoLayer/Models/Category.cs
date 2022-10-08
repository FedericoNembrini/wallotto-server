using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocoLayer.Models
{
    public class Category
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Description { get; set; } = string.Empty;

        [ForeignKey(nameof(Category))]
        public long? ParentId { get; set; }

        public virtual Category? ParentCategory { get; set; }
    }
}
