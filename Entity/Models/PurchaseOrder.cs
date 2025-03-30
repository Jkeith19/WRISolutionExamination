using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateOfDelivery { get; set; }
        [Required]
        public required string Status { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public double AmountDue { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string? Createdby { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public bool? IsActive { get; set; }
        public int CustomerId { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
