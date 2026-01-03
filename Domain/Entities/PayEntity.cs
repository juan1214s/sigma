using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using technical_test_sigma.Domain.Enums;

namespace technical_test_sigma.Domain.Entities
{
    public class PaymentEntity
    {
        [Key]
        public Guid PaymentId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public bool Authorized { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public CustomerEntity Customer { get; set; }
    }
}
