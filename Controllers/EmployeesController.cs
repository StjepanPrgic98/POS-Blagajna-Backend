using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.Data;
using POS_Blagajna_Backend.DTOs.EmployeeDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Controllers
{
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;   
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            try
            {
                return Ok(await _employeeService.GetAllEmployees());
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not get employees! \n {ex}");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                return await _employeeService.CreateEmployee(employeeDTO);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not create new employee! \n {ex}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            try
            {
                return await _employeeService.DeleteEmplyoee(id);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not delete employee! \n {ex}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                return await _employeeService.UpdateEmployee(employeeDTO);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not update employee! \n {ex}");
            }
        }
    }
}