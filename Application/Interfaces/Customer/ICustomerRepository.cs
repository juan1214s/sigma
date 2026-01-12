using technical_test_sigma.Domain.Entities;

namespace technical_test_sigma.Application.Interfaces.Customer
{
    public interface ICustomerRepository
    {
        Task AddAsync(CustomerEntity customer);
        Task<CustomerEntity> GetByIdAsync(Guid id);
        Task UpdateAsync(CustomerEntity customer);
        
    }
}
