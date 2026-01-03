using technical_test_sigma.Application.Interfaces.Customer;
using technical_test_sigma.Domain.Entities;
using technical_test_sigma.DTO.CrmDto;
using technical_test_sigma.DTO.CustomerDto;

namespace technical_test_sigma.Application.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICrmService _crmService;

        public CustomerService(ICustomerRepository customerRepository, ICrmService crmService)
        {
            _customerRepository = customerRepository;
            _crmService = crmService;
        }

        public async Task<Guid> CreateCustomerAsync(CustomerCreateDto dto)
        {
            var customer = new CustomerEntity
            {
                CustomerId = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                RegistrationDate = DateTime.UtcNow,
                IsActive = true,
                Address = new AddressEntity
                {
                    AddressId = Guid.NewGuid(),
                    Street = dto.Address.Street,
                    City = dto.Address.City,
                    Country = dto.Address.Country
                },
                Payments = new List<PaymentEntity>
                {
                    new PaymentEntity
                    {
                        PaymentId = Guid.NewGuid(),
                        PaymentMethod = dto.Pay.PaymentMethod,
                        Amount = dto.Pay.Amount,
                        Authorized = dto.Pay.Authorized,
                        PaymentDate = DateTime.UtcNow
                    }
                }
            };

            await _customerRepository.AddAsync(customer);

            await _crmService.CreateOrUpdateCustomerAsync(new CrmCustomerDto
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                TotalPaid = dto.Pay.Amount
            });
            return customer.CustomerId;
        }

        public async Task<CustomerRespondsDto> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            var lastPayment = customer.Payments
                .OrderByDescending(p => p.PaymentDate)
                .FirstOrDefault();

            return new CustomerRespondsDto
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                RegistrationDate = customer.RegistrationDate,
                TotalPay = customer.Payments.Sum(p => p.Amount),
                PaymentMethod = lastPayment?.PaymentMethod.ToString(),
                Status = customer.IsActive ? "Active" : "Inactive"
            };
        }

        public async Task ChangeStatusAsync(Guid id, bool isActive)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            customer.IsActive = isActive;
            await _customerRepository.UpdateAsync(customer);
        }
    }
}
