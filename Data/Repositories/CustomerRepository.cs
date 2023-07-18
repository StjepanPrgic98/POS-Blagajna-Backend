using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;

namespace POS_Blagajna_Backend.Data.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }


        public async Task<bool> UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Customer>> GetCustomersThatContainsName(string name)
        {
            return await _context.Customers.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }
    }
}