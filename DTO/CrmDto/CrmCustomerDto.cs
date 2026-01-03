namespace technical_test_sigma.DTO.CrmDto
{
    public class CrmCustomerDto
    {
        public Guid CustomerId { get; set; } 
        public string Name { get; set; }        
        public string Email { get; set; }       
        public decimal TotalPaid { get; set; }  
    }
}
