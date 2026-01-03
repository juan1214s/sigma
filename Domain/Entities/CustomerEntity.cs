using System.ComponentModel.DataAnnotations;

namespace technical_test_sigma.Domain.Entities
{
    public class CustomerEntity
    {
        [Key]
        public Guid CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        // 1 - 1
        public AddressEntity Address { get; set; }

        // 1 - N
        public ICollection<PaymentEntity> Payments { get; set; } = new List<PaymentEntity>();
    }
}
