using technical_test_sigma.DTO.CrmDto;

namespace technical_test_sigma.Application.Interfaces.Customer
{
    public interface ICrmService
    {
        Task CreateOrUpdateCustomerAsync(CrmCustomerDto dto);
    }
}
