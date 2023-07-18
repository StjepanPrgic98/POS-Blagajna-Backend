using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.EmployeeDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.ServiceInterfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<bool> CreateEmployee(EmployeeDTO employeeDTO);
        Task<bool> UpdateEmployee(EmployeeDTO employeeDTO);
        Task<bool> DeleteEmplyoee(int id);

        Task<EmployeeDTO> Register(RegisterEmployeeDTO registerEmployeeDTO);
        Task<EmployeeDTO> Login(RegisterEmployeeDTO registerEmployeeDTO);
    }
}