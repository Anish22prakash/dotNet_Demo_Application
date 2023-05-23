using entityFrameWork.Model;
using Microsoft.EntityFrameworkCore;

namespace entityFrameWork.Service
{
    public class EmployeeService : IEmployeeService

    {

        public EmployeContext _empContext;

        public EmployeeService(EmployeContext empContext)
        {
            _empContext = empContext;
        }

        string IEmployeeService.createEmployee(Employee employee)
        {
           var createEmployee = new Employee();
            createEmployee.EmployeeFirstName = employee.EmployeeFirstName;
            createEmployee.EmployeeLastName = employee.EmployeeLastName;
            createEmployee.Salary = employee.Salary;
            createEmployee.Designation= employee.Designation;



            if (createEmployee != null)
            {
                _empContext.Add(createEmployee);
                _empContext.SaveChanges();
                return "employee is created";
            }
            else {

                return "pass the valid employee";

            }
        }

        List<Employee> IEmployeeService.getAllEmployee()
        {
           
            List<Employee> emplist;
            try
            {
                emplist = _empContext.Set<Employee>().ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
            return emplist;
           

            
        }

         Employee IEmployeeService.getEmployeeById(int id)
        {
            IEnumerable<Employee> ep= from employee in _empContext.Set<Employee>() 
                                      where employee.EmployeeId==id
                                      select employee;


            Employee emp=ep.FirstOrDefault();
            
             /*  try
                {
                    emp = _empContext.Find<Employee>(id);
                }
                catch (Exception)
                {
                    throw;
                }
             */
            return emp;
            
        }

        public string deleteEmployee(int id)
        {
               

            try
            {
                Employee em = _empContext.Find<Employee>(id);
                if (em != null)
                {
                    _empContext.Remove(em);
                    _empContext.SaveChanges();

                    return "employee is deleted";
                }
                else {
                    return "id is not valid";
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        //get the min salary
        public List<Employee> getEmployeWithSalaryAmountMoreThan(int amount)
        {
            IEnumerable<Employee> sry = from emp in _empContext.Set<Employee>()
                                         where emp.Salary > amount
                                         select emp;
            List<Employee> list = new List<Employee>();
           // Console.WriteLine("LOWEST SALARY");


            foreach(var emp in sry)
            {
                Employee employee = new Employee();
                employee.EmployeeId= emp.EmployeeId;
                employee.Designation= emp.Designation;  
                employee.Salary = emp.Salary;
                employee.EmployeeFirstName=emp.EmployeeFirstName; 
                employee.EmployeeLastName=emp.EmployeeLastName;
                list.Add(employee);
            }
           // Console.WriteLine(list.Min());
            if (list.Count > 0)
                return list;
            else
                return null;
          
        }

        //orderbySalary

        public List<Employee>? orderByEmpBySalary()
        {
            IEnumerable<Employee> empolyeeList = from ep in _empContext.Set<Employee>()
                                        orderby ep.Salary
                                        select ep;
            return empolyeeList.ToList();
           

        }

        public Employee getMinSalaryEmp()
        {
           //var emp1 = (from ep in _empContext.Set<Employee>()
             //          select ep).Min(x => x.Salary);

            var emp = _empContext.Employees.Min(x => x.Salary);

            var emp4 = _empContext.Employees.FirstOrDefault();

            return emp;

        }
    }
}
