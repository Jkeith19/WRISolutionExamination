using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public class Sku
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Code { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public double UnitPrice { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
