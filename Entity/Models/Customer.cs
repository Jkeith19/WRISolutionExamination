using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public required string FisrtName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string FullName { get; set; }
        [Required]
        public required string MobileNumber { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string? Createdby { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public bool IsActive { get; set; }
        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
    }
}
