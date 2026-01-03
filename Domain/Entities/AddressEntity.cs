using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace technical_test_sigma.Domain.Entities
{
    public class AddressEntity
    {
        [Key]
        public Guid AddressId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [StringLength(150)]
        public string Street { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public CustomerEntity Customer { get; set; }
    }
}
