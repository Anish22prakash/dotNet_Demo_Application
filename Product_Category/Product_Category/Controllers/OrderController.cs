using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Category.DataBaseContext;
using Product_Category.Model;

namespace Product_Category.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MyDataBase _dataBasse;

        public OrderController(MyDataBase dataBasse) { 
        _dataBasse = dataBasse;
          }

        [HttpGet]
        public List<Orders> getAllOrder()
        {
            return _dataBasse.orders.ToList();
        }

        [HttpPost]
        public IActionResult createOrder(Orders ord)
        {
            Orders orders = new Orders();
            orders.OrderDate = DateTime.Now;
            orders.CustomerId = ord.CustomerId;
            orders.PaymentId = ord.PaymentId;
            orders.TotalAmount = ord.TotalAmount;

            _dataBasse.orders.Add(orders);
            _dataBasse.SaveChanges();

            return Ok("order is created");
         }

        [HttpDelete]
        public IActionResult deleteOrder(int orderId)
        {
            var or= new Orders() { OrderId = orderId };
            _dataBasse.orders.Remove(or);
            _dataBasse.SaveChanges();
            return Ok("order is deleted");
        }
        [HttpGet]
        public IActionResult getOrderById(int orderId)
        {
            var response = _dataBasse.orders.Where(x => x.OrderId == orderId).Select(x => new Orders()
            {
                OrderId = x.OrderId,
                CustomerId = x.CustomerId,
                PaymentId = x.PaymentId,
                TotalAmount = x.TotalAmount
                                
            });
            return Ok(response);

        }
    }
}
