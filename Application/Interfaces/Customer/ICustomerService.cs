using technical_test_sigma.DTO.CustomerDto;

namespace technical_test_sigma.Application.Interfaces.Customer
{
    public interface ICustomerService
    {
        Task<Guid> CreateCustomerAsync(CustomerCreateDto dto);
        Task<CustomerRespondsDto> GetCustomerByIdAsync(Guid id);
        Task ChangeStatusAsync(Guid id, bool isActive);
    }
}
