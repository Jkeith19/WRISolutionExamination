using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public int SkuId { get; set; }
        public int PurchaseOrderId { get; set; }
    }
}
