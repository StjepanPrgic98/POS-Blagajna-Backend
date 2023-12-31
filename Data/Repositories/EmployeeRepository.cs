using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.DTOs.EmployeeDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;

namespace POS_Blagajna_Backend.Data.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmplyoee(Employee employee)
        {
            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync() > 0;          
        }


        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}