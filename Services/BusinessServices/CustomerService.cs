using AutoMapper;
using Entity.AppContext;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Services.ORM.Configuration.Mapper.CustomerMap;
using Services.ORM.Dtos.CustomerDto;

namespace Services.BusinessServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetCustomersAsync(int page, int count);
        Task<bool> AddCustomerAsync(Customer customer);
        Task<bool> EditCustomerAsync(int id, Customer customer);
    }

    public class CustomerService : ICustomerService
    {
        public readonly ApplicationDbContext _context;
        public readonly ICustomerMapper _customerMapper;
        public readonly IMapper _mapper;

        public CustomerService(ApplicationDbContext context, ICustomerMapper customerMapper)
        {
            _context = context;
            _customerMapper = customerMapper;
            _mapper = _customerMapper.CustomerConfiguration();
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync(int page, int count)
        {
            var result = await _context.Customers
                .Skip(page * count)
                .Take(count)
                .ToListAsync();

            return _mapper.Map<List<CustomerDto>>(result);
        }

        public async Task<bool> AddCustomerAsync(Customer customer)
        {
            var validateCustomer = await ValidateCustomerAsync(customer.FullName, customer.MobileNumber);

            if(validateCustomer)
            {
                return false;
            }

            await AddProcessAsync(customer);

            return true;
        }

        public async Task<bool> EditCustomerAsync(int id, Customer customer)
        {
            var findCustomer = await GetCustomerAsync(id);
            
            if (findCustomer == null) {
                return false;
            }

            customer.Id = id;

            await EditProcessAsync(customer);
            return true;
        }

        private async Task<bool> ValidateCustomerAsync(string fullname, string phoneNumber)
        {
            return await _context.Customers.AnyAsync(
                x => x.FullName.ToLower().Equals(fullname.ToLower()) ||
                x.MobileNumber.Equals(phoneNumber));
        }

        private async Task<Customer?> GetCustomerAsync(int id)
        {
            return await _context.Customers
                        .AsNoTracking()
                        .FirstOrDefaultAsync(c => c.Id == id);
        }

        private async Task AddProcessAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        private async Task EditProcessAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
