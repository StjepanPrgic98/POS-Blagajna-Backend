using POS_Blagajna_Backend.DTOs.EmployeeDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;     
        }

        public async Task<bool> CreateEmployee(EmployeeDTO employeeDTO)
        {
            Employee newEmployee = new Employee
            {
                Name = employeeDTO.Name
            };

            return await _employeeRepository.CreateEmployee(newEmployee);
        }

        public async Task<bool> DeleteEmplyoee(int id)
        {
            Employee employeeToDelete = await _employeeRepository.GetEmployeeById(id);
            return await _employeeRepository.DeleteEmplyoee(employeeToDelete);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<bool> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employeeToUpdate = await _employeeRepository.GetEmployeeById(employeeDTO.Id);

            employeeToUpdate.Name = employeeDTO.Name;

            return await _employeeRepository.UpdateEmployee(employeeToUpdate);
        }
    }
}