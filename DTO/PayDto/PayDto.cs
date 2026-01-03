using System.ComponentModel.DataAnnotations;
using technical_test_sigma.Domain.Enums;

namespace technical_test_sigma.DTO.PayDto
{
    public class PayDto
    {
        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public bool Authorized { get; set; }
    }
}
