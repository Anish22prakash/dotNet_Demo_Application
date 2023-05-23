using entityFrameWork.Model;

namespace entityFrameWork.Service
{
    public interface IEmployeeService
    {
        public List<Employee> getAllEmployee();
        public  Employee getEmployeeById(int id);
         public String createEmployee(Employee employee);

        public string deleteEmployee(int id);


        public List<Employee> getEmployeWithSalaryAmountMoreThan(int amount);
        public List<Employee> orderByEmpBySalary();
    }
}
