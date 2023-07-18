using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS_Blagajna_Backend.DTOs.EmployeeDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<bool> CreateEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmplyoee(Employee employee);

        Task<Employee> GetEmployeeById(int id);

        Task<bool> Register(Employee employee);
        Task<EmployeeDTO> Login(RegisterEmployeeDTO registerEmployeeDTO);
    }
}