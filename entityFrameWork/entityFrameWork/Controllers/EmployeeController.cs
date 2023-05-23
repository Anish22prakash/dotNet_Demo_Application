using entityFrameWork.Model;
using entityFrameWork.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace entityFrameWork.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService service)
        {
            _employeeService = service;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
           List<Employee> result= _employeeService.getAllEmployee();
            if (result.Count == 0)
            {
                return NoContent();
            }
            else { 
            return Ok(result);
            }
        }

        [HttpGet]
        public IActionResult GetEmployeeById(int id)

        {
            

            Employee result= _employeeService.getEmployeeById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else { 
            return NotFound();
            }
        }

        [HttpPost]
        public IActionResult PostEmployee(Employee employee) 
        {
         String result =_employeeService.createEmployee(employee);
            if(result != null)
            {
                return Ok(result);
            }
            else{
                return BadRequest();
            }
        
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            String result= _employeeService.deleteEmployee(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public List<Employee> getEmployewithHigherSalary(int amount)
        {
            List<Employee> emp= _employeeService.getEmployeWithSalaryAmountMoreThan(amount);

            return emp;
        }

        [HttpGet]
        public List<Employee> getOrderBySalary()
        {
            List<Employee> emp = _employeeService.orderByEmpBySalary();
            return emp;
        }



    }
}
