using System.ComponentModel.DataAnnotations;

namespace PocoLayer.Models
{
    public class Currency
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;
    }
}
