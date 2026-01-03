namespace technical_test_sigma.DTO.CustomerDto
{
    public class CustomerRespondsDto
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal TotalPay { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
