namespace wallotta_server.Models
{
    public class CategoryDTO
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Description { get; set; } = string.Empty;

        public long? ParentId { get; set; }

        public CategoryDTO? ParentCategory { get; set; }
    }
}
