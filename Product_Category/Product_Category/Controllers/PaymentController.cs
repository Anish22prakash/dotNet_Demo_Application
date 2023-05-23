using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Category.DataBaseContext;
using Product_Category.Model;

namespace Product_Category.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly MyDataBase _dataBase;

        public PaymentController(MyDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpPost]
        public IActionResult createPayment(Payment payment)
        {
            Payment py= new Payment();
            py.PaymentType = payment.PaymentType;

            _dataBase.payments.Add(py);
            _dataBase.SaveChanges();
            return Ok("payment is created");

        }
        [HttpDelete]
        public IActionResult deletePayment(int id)
        {
            var py= new Payment() { PaymentId = id };

            _dataBase.payments.Remove(py);
            _dataBase.SaveChanges();

            return Ok("payment is deleted");
        }
    }
}
