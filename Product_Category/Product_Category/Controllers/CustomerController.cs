using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Category.DataBaseContext;
using Product_Category.Model;

namespace Product_Category.Controllers
{
    [Route("[controller]/[action]")]
    
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly MyDataBase _dataBase;

        public CustomerController(MyDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        public List<Customer> getAllCustomer()
        {
            return _dataBase.customers.ToList();
        }

        [HttpGet]
        public IActionResult getCustomerById(int id)
        {
            var response = _dataBase.customers.Where(x => x.CustomerId == id).Select(x => new Customer()
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                city = x.city,
                country = x.country,
                phone = x.phone
            });
            return Ok(response);
        }

        [HttpPost]
        public IActionResult createCustomer(Customer customer)
        {
            Customer cs = new Customer();
            cs.CustomerName = customer.CustomerName;
            cs.phone = customer.phone;
            cs.city = customer.city;
            cs.country = customer.country;

            _dataBase.customers.Add(cs);
            _dataBase.SaveChanges();

            return Created("~/Customer/" + customer.CustomerId, customer);

        }
        [HttpPut]
        public IActionResult updateCustomer(int id, Customer customer)
        {
            var cs = new Customer()
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                city = customer.city,
                country = customer.country,
                phone = customer.phone

            };
            _dataBase.customers.Update(cs);
            _dataBase.SaveChanges();
            return Ok("customer data is updated");
        }

        [HttpDelete]
        public IActionResult deleteCustomer (int id)
        {
            var cs = new Customer() { CustomerId = id };
            _dataBase.customers.Remove(cs);
            _dataBase.SaveChanges();

            return Ok("account deleted");
        }
    }
}
