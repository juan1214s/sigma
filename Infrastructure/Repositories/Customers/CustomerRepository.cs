using Microsoft.EntityFrameworkCore;
using technical_test_sigma.Application.Interfaces.Customer;
using technical_test_sigma.Domain.Entities;
using technical_test_sigma.Infrastructure.Data;

namespace technical_test_sigma.Infrastructure.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CustomerEntity customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<CustomerEntity> GetByIdAsync(Guid id)
        {
            return await _context.Customers
                .Include(c => c.Address)
                .Include(c => c.Payments)
                .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task UpdateAsync(CustomerEntity customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
